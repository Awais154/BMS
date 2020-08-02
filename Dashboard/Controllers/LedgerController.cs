using Dashboard.Models;
using DATA.Domains;
using Provider.Ledger;
using Provider.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dashboard.Controllers
{
    public class LedgerController : Controller
    {
        private readonly LedgerProvider ledgerProvider;
        private readonly ProductProvider productprovider;
        public LedgerController()
        {
            {
                productprovider = new ProductProvider();
                ledgerProvider = new LedgerProvider();
            }
        }

        public ActionResult AddExpense()
        {
            var accountholder = productprovider.getaccountholders();
            TempData["AccountHolder"] = accountholder;

            var insertiontype = productprovider.getInsertionType();
            TempData["InsertionType"] = insertiontype;
            return View();
        }

        [HttpPost]
        public ActionResult AddExpense(AmountModel model)
        {
            var UserInfo = (Dashboard.Models.UserInfo)Session["UserInfo"];

            

            var ledgerForAccountHolder = ExpenseLedger(model.InsertionTypeId, UserInfo.UserId, model.AmountIn, model.AmountOut, model.AccountHolderId);
            ledgerProvider.SaveLedger(ledgerForAccountHolder);

            var trademarkaccountholder = productprovider.gettrademarakaccountholder(UserInfo.TrademarkID);

            var ledgerFortradeMark = ExpenseLedger(model.InsertionTypeId, UserInfo.UserId, model.AmountOut, model.AmountIn, trademarkaccountholder.Id);
            ledgerProvider.SaveLedger(ledgerFortradeMark);

            return RedirectToAction("AddExpense");

        }

        public ActionResult GetLedger()
        {
            var accountholder = productprovider.getaccountholders();
            TempData["AccountHolder"] = accountholder;

            var insertiontype = productprovider.getInsertionType();
            TempData["InsertionType"] = insertiontype;

            var UserInfo = (Dashboard.Models.UserInfo)Session["UserInfo"];

            DateTime toDate = DateTime.Now;
            DateTime fromdate = toDate.AddDays(-30);

            var ledgerlist = ledgerProvider.GetLedger(toDate, fromdate, 0, 0, UserInfo.TrademarkID);
            return View(ledgerlist);
        }

        [HttpPost]
        public ActionResult GetLedger(SearchLedgerModel model)
        {
            var accountholder = productprovider.getaccountholders();
            TempData["AccountHolder"] = accountholder;

            var insertiontype = productprovider.getInsertionType();
            TempData["InsertionType"] = insertiontype;

            var UserInfo = (Dashboard.Models.UserInfo)Session["UserInfo"];

            var ledger=ledgerProvider.GetLedger(model.DateTo, model.DateFrom, model.AccountHolderId, model.InsertionTypeId, UserInfo.TrademarkID);
            return View(ledger);
        }
        #region private

        private DATA.Domains.Ledger ExpenseLedger(int insertiontypeid, int userid, decimal amountIn, decimal amountOut,int accountHolderid)
        {
            Ledger ledger = new Ledger
            {
                AmountIn = amountIn,
                AmountOut = amountOut,
                CreatedOn = DateTime.Now,
                Transection = "This is Expense Ledger",
                UserId = userid,
                AccountHolderId = accountHolderid,
                InsertionTypeId = insertiontypeid
            };
            return ledger;
        }
        #endregion
    }
}