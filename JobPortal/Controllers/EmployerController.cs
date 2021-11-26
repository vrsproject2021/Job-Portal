using JobPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortal.Controllers
{
    public class EmployerController : Controller
    {

        private DBOperationDataContext _context;

        public EmployerController()
        {
            _context = new DBOperationDataContext();
        }
        // GET: Employer
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
        //{
        //    if (ModelState.IsValid)
        {
            var loginDetails = _context.user_accounts.Where(u => u.email_id == email_id && u.password == password && u.user_type == "jobprovider").FirstOrDefault();
            if (loginDetails != null)

            {
                Session["User"] = loginDetails.email_id;
                Session["UserId"] = loginDetails.id;
                if (loginDetails.user_type == "jobprovider")
                {
                    return RedirectToAction("Index", "Employer");
                }



                else
                {
                    ViewBag.Error = "Incorrect password or email address";
                    return View();
                }
                //}

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
            if (ModelState.IsValid)
            {
                var newUser = new user_account();
                newUser.email_id = newuserobj.email_id;
                newUser.password = newuserobj.password;
                newUser.phone_number = newuserobj.phone_number;
                newUser.user_type = "jobprovider";
                _context.user_accounts.InsertOnSubmit(newUser);
                _context.SubmitChanges();
                return RedirectToAction("Login", "Employer");

            }

            return View();
        }

        public ActionResult Jobpost()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Jobpost(provider jobpostobj)
        {
            var jobPost = new job_post();
            //jobPost.posted_by_id = jobpostobj.posted_by_id;
            jobPost.posted_by_id = (int)Session["UserId"];
            jobPost.job_type_id = jobpostobj.job_type_id;
            jobPost.company_id = jobpostobj.company_id;
            jobPost.created_date = jobpostobj.created_date;
            jobPost.job_description = jobpostobj.job_description;
            jobPost.job_location_id = jobpostobj.job_location_id;
            jobPost.is_active = jobpostobj.is_active;
            _context.job_posts.InsertOnSubmit(jobPost);
            _context.SubmitChanges();
            return RedirectToAction("LocationModel", "Employer");

        }


        public ActionResult CompanyModel()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult CompanyModel(CompanyModel companyobj)
        {
            var companyDetails = new company();
            companyDetails.company_name = companyobj.company_name;
            companyDetails.profile_description = companyobj.profile_description;
            companyDetails.business_stream_id = companyobj.business_stream_id;
            companyDetails.establishment_date = companyobj.establishment_date;
            companyDetails.company_website_url = companyobj.company_website_url;
            _context.companies.InsertOnSubmit(companyDetails);
            _context.SubmitChanges();
            return RedirectToAction("Index", "Employer");

        }

        public ActionResult LOGOUT()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Employer");
        }
        public ActionResult LocationModel()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult LocationModel(LocationModel locationobj)
        {
            var joblocation = new job_location();
            joblocation.street_address = locationobj.street_address;
            joblocation.city = locationobj.city;
            joblocation.state = locationobj.state;
            joblocation.country = locationobj.country;
            joblocation.zip = locationobj.zip;
            _context.job_locations.InsertOnSubmit(joblocation);
            _context.SubmitChanges();
            return RedirectToAction("CompanyModel", "Employer");

        }
        //public ActionResult CompanyImage()
        //{
        //    return View();
        //}

    }
}