using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LOGIN.Models;

namespace LOGIN.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Autherize(LOGIN.Models.User userModel)
        {
            using (LoginDataBaseEntities1 db = new LoginDataBaseEntities1())
            {
                var userDetails = db.Users.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();
                if(userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong Username or Password";
                    return View("Index", userModel);
                }
                else
                {
                    Session["UserID"] = userDetails.UserID;
                    Session["UserName"] = userDetails.UserName;
                    return RedirectToAction("Index", "Home");
                }

            }
              
        }
        public ActionResult LogOut()
        {
            int UserID = (int)Session["UserID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");

        }

    }
}