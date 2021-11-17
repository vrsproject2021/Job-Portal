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
        public ActionResult Login(UserModel userobj)
        {
            if (ModelState.IsValid)
            {
                var loginDetails = _context.user_accounts.Where(u => u.email_id == userobj.email_id && u.password == userobj.password &&u.user_type == "jobseeker").FirstOrDefault();
                if (loginDetails != null)
                {
                    Session["User"] = userobj.email_id;
                    Session["UserId"] = userobj.id;

                    return RedirectToAction("Index","Applicant");
                }
                else
                {
                    return View();
                }

            }
            else 
            { 
                return View(); 
            }

        }
    }
}