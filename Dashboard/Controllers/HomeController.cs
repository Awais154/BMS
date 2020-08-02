using Dashboard.Models;
using Provider.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dashboard.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserProvider userProvider;
        private readonly int UserName=0;
        private readonly int Email = 1;
        private readonly int TradeMarkID = 2;
        private readonly int Role = 3;

        public HomeController()
        {
            userProvider = new UserProvider();
           
        }

        public ActionResult Index()
        {
            var email = GetValueOfCookie(Email);
            var username = GetValueOfCookie(UserName);
            var tradeMarkID = GetValueOfCookie(TradeMarkID);
            var role = GetValueOfCookie(Role);
            var userId = userProvider.GetEmail(email);
            UserInfo userInfo = new UserInfo
            {
                Email = email,
                Role = role,
                TrademarkID = Convert.ToInt32(tradeMarkID),
                UserName = username,
                UserId = userId.Id
            };
            Session["UserInfo"] = userInfo;
            return View();
        }

        private string GetValueOfCookie(int index)
        {
            var value = Request.Cookies["userInfo"].Value;

            var keyValues = value.Split('&');
            var values = keyValues[index].Split('=');
            return values[1].ToString();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}