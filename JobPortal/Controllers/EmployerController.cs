using JobPortal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
        public string encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email_id, string password)
        {
            password = encrypt(password);
            if (ModelState.IsValid)
            {
                var loginDetails = _context.user_accounts.Where(u => u.email_id == email_id && u.password == password && u.user_type == "jobprovider").FirstOrDefault();
                if (loginDetails != null)
                {
                    Session["User"] = loginDetails.email_id;
                    Session["UserId"] = loginDetails.id;

                    return RedirectToAction("Index", "Employer");
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
            if (ModelState.IsValid)
            {
                var newUser = new user_account();
                newUser.email_id = newuserobj.email_id;
                newUser.password = newuserobj.password;
                newUser.phone_number = newuserobj.phone_number;
                newUser.user_type = "jobprovider";
                _context.user_accounts.InsertOnSubmit(newUser);
                _context.SubmitChanges();
                TempData["Message"] = "Successfully Registered";
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
            if (ModelState.IsValid)
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

            else
            {
                return View();
            }

        }


        public ActionResult CompanyModel()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Employer");
            }
            //return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult CompanyModel(CompanyModel companyobj)
        {
            if (ModelState.IsValid)
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
            else
            {
                return View();
            }


        }

        public ActionResult LOGOUT()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Employer");
        }
        [HttpGet]
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