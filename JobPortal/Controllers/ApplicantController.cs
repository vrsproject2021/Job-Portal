using JobPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortal.Controllers
{
    public class ApplicantController : Controller
    {
        private DBOperationDataContext _context;

        public ApplicantController() 
        {
            _context = new DBOperationDataContext();
        }
        // GET: Applicant
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email_id, string password)
        {
            if (ModelState.IsValid)
            {
                var loginDetails = _context.user_accounts.Where(u => u.email_id == email_id && u.password == password &&u.user_type == "jobseeker").FirstOrDefault();
                if (loginDetails != null)
                {
                    Session["User"] = loginDetails.email_id;
                    Session["UserId"] = loginDetails.id;

                    return RedirectToAction("Index","Applicant");
                }
                else
                {
                    ViewBag.Error = "Incorrect password or email address";
                    return View();
                }

            }
            else 
            { 
                return View(); 
            }

        }

        public ActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Register(UserModel newuserobj) 
        {
            ModelState.Remove("ConfirmPassword");
            if (ModelState.IsValid) {
                Console.WriteLine("is valid");
                var newUser = new user_account();
                newUser.email_id = newuserobj.email_id;
                newUser.password = newuserobj.password;
                newUser.phone_number = newuserobj.phone_number;
                newUser.user_type = "jobseeker";
                _context.user_accounts.InsertOnSubmit(newUser);
                _context.SubmitChanges();
                return RedirectToAction("Login","Applicant");
            
            }

            Console.WriteLine("is not valid");

            return View(); 
        }
    }
}