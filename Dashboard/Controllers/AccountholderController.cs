using Dashboard.Models;
using Provider.AccountHolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dashboard.Controllers
{
    public class AccountholderController : Controller
    {
        private readonly AccountHolderProvider accountHolderProvider;

        public AccountholderController()
        {
            accountHolderProvider = new AccountHolderProvider();
        }

        public ActionResult Add()
        {
            var accountholderTypes = accountHolderProvider.GetAccountHolderType();
            return View(accountholderTypes);
        }

        [HttpPost]
        public ActionResult Add(DATA.Domains.AccountHolder accountHolder)
        {
            try
            {
                var checkContacts = accountHolderProvider.GetContact(accountHolder.Contact);
                if (checkContacts == null)
                {
                    accountHolderProvider.Add(accountHolder);
                    TempData["alert"] = GetAlert("Account Holder added successfully", "success");
                }
                else
                {
                    TempData["alert"] = GetAlert("contact already exists","error");
                }
                var accountholderTypes = accountHolderProvider.GetAccountHolderType();
                return View(accountholderTypes);
            }

            catch
            {
                var accountholderTypes = accountHolderProvider.GetAccountHolderType();
                TempData["alert"] = GetAlert("Account Holder not added successfully", "error");
                return View(accountholderTypes);
            }
        }

        public ActionResult Get()
        {
            var UserInfo = (Dashboard.Models.UserInfo)Session["UserInfo"];
            var accountholders = accountHolderProvider.Get(UserInfo.TrademarkID);
            return View(accountholders);
        }

        public ActionResult Edit(int id)
        {
            var accountholderTypes = accountHolderProvider.GetAccountHolderType();

            TempData["AccountHolderType"] = accountholderTypes;

            var acountholder = accountHolderProvider.GetByID(id);

            return View(acountholder);
        }

        [HttpPost]
        public ActionResult Update(DATA.Domains.AccountHolder accountHolder)
        {
            accountHolderProvider.Update(accountHolder);

            return RedirectToAction("get");
        }

        public ActionResult Delete(int id)
        {
            accountHolderProvider.Delete(id);
            return RedirectToAction("Get");
        }
        #region private
        private Alert GetAlert(string alertMessage, string alertType)
        {
            return new Alert
            {
                AlertMessage = alertMessage,
                AlertType = alertType

            };
        }
        #endregion
    }
}