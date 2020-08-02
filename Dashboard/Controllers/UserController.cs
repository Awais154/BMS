using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Provider.User;
using Dashboard.Models;

namespace Dashboard.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserProvider userProvider;

        public UserController()
        {
            userProvider = new UserProvider();
        }

        public ActionResult Get()
        {
            var UserInfo = (Dashboard.Models.UserInfo)Session["UserInfo"];
            var user = userProvider.GetUser(UserInfo.TrademarkID);
            return View(user);
        }
        //to change password of user
        public ActionResult Edit(int id)
        {
            var users = userProvider.GetById(id);
            return View(users);
        }
        [HttpPost]
        public ActionResult update(DATA.Domains.User user)
        {
            userProvider.update(user);
            return RedirectToAction("get");
        }
        #region Wajhat

        //public ActionResult UserProfile(UserModel userModel)
        //{
        //    int trademarkid = 1;
        //    var user = userProvider.GetUser(trademarkid);
        //    return View(maptomodel(user));

        //}

        //[HttpPost]
        //public ActionResult UpdateUser(UserModel userModel)
        //{
        //   int trademarkid = 1;
        //    var updated = mapping(userModel, trademarkid);
        //    var result = userProvider.UpdateUser(updated);
        //    return RedirectToAction("UserProfile", result);
        //}

        //private UserModel maptomodel(DATA.Domains.User user)
        //{
        //    UserModel userModel = new UserModel();
        //    userModel.TradeMarkId = user.TradeMarkId;
        //    userModel.Email = user.Email;
        //    userModel.FirstName = user.FirstName;
        //    userModel.LastName = user.LastName;
        //    userModel.Password = user.Password;
        //    userModel.Id = user.Id;
        //    return userModel;
        //}
        //private DATA.Domains.User mapping(UserModel userModel, int trademarkid)
        //{
        //    DATA.Domains.User user = new DATA.Domains.User();
        //    user.TradeMarkId = trademarkid;
        //    user.Email = userModel.Email;
        //    user.FirstName = userModel.FirstName;
        //    user.LastName = userModel.LastName;
        //    user.Password = userModel.Password;
        //    user.Id = userModel.Id;
        //    return user;
        //}


        #endregion
    }
}