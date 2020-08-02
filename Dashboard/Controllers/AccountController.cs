using Dashboard.Models;
using Provider.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Dashboard.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserProvider userprovider;

        public AccountController()
        {
            userprovider = new UserProvider();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model, string returnUrl)
        {
            
            if (ModelState.IsValid)
            {

                string username = model.EmailAddress;
                string password = model.Password;

                var user = userprovider.Authenticate(model.EmailAddress, model.Password);
                bool exist = false;

                if (user.Email == username && user.Password == password)
                {
                    exist = true;
                }

                if (exist)
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);

                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        HttpCookie userInfo = new HttpCookie("userInfo");
                        userInfo["UserName"] = user.FirstName + " " + user.LastName;
                        userInfo["Email"] = user.Email;
                        userInfo["TradeMarkId"] = user.TradeMarkId.ToString();
                        userInfo["Role"] = user.Role.ToString();
                        userInfo.Expires.Add(new TimeSpan(2, 0, 0));
                        Response.Cookies.Add(userInfo);

                        return RedirectToAction("Index", "Home");
                    }
                
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            return View(model);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "account");
        }
    }
}