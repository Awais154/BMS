using Dashboard.Models;
using Provider.AccountHolder;
using Provider.TradeMark;
using Provider.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dashboard.Controllers
{
    [Authorize]
    public class TrademarkController : Controller
    {
        private readonly TrademarkProvider trademarkProvider;
        private readonly UserProvider userProvider;
        private readonly AccountHolderProvider accountHolderProvider;


        public TrademarkController()
        {
            trademarkProvider = new TrademarkProvider();
            userProvider = new UserProvider();
        }

        public ActionResult Index()
        {
            var trademarks = trademarkProvider.Get();

            return View(trademarks);
        }


        public ActionResult Add()
        {
            //var accountholderTypes = accountHolderProvider.GetAccountHolderType();
            //return View(accountholderTypes);
            return View();
        }

        [HttpPost]
        public ActionResult Add(DATA.Domains.Trademark trademark)
        {
            try
            {
                trademark.UniqueKey = Guid.NewGuid().ToString();
                trademark.OnTrial = false;
                trademark.User.FirstOrDefault().Role = "Admin";
                trademark.TrialExpired = false;
                trademark.TrialStartedOn = DateTime.Now;
                trademark.TrialPeriod = 30;
                trademark.User.FirstOrDefault().CreatedOn = DateTime.Now;
                var checkEmail = userProvider.GetEmail(trademark.User.FirstOrDefault().Email);
                if (checkEmail == null)
                {
             
                    TempData["alert"] = GetAlert("TradeMark added successfully", "Success");

                    DATA.Domains.AccountHolder accountHolder = new DATA.Domains.AccountHolder
                    {
                        FirstName = trademark.OwnerName,
                        TradeMarkUniqueKey = trademark.UniqueKey,
                        Address = trademark.Address,
                        Detail = trademark.Detail,
                        Contact = trademark.Contact,
                        AccountHolderTypeID = 4,
                        CreatedOn = trademark.CreatedOn
                    };
                    trademark.AccountHolder.Add(accountHolder);
                    var trademarkId = trademarkProvider.Add(trademark);
                }

                else
                {
                    TempData["alert"] = GetAlert("Email Already Exists", "error");
                }
             
                return View();

            }
            catch (Exception ex)
            {
                TempData["alert"] = GetAlert("TradeMark not added successfully", "error");
                return View();
            }
        }

        public ActionResult Get()
        {
            var trademark = trademarkProvider.Get();
            return View(trademark);
        }

        public ActionResult Edit(int id)
        {
            var trademarks = trademarkProvider.GetById(id);
            return View(trademarks);
        }
        [HttpPost]
        public ActionResult Update(DATA.Domains.Trademark trademark)
        {
            trademarkProvider.Update(trademark);
            return RedirectToAction("get");
        }

        public ActionResult Delete(int id)
        {
            trademarkProvider.Delete(id);
            return RedirectToAction("Get");
        }

        #region Private

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