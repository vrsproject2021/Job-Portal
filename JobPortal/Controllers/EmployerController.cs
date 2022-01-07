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
                var password = encrypt(newuserobj.password);
                var newUser = new user_account();
                newUser.email_id = newuserobj.email_id;
                newUser.password = password;
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
            if (Session["UserId"] != null)
            {
                var skills = _context.skill_sets.ToList();



                List<SelectListItem> skillItem = new List<SelectListItem>();



                foreach (var item in skills)
                {
                    skillItem.Add(new SelectListItem() { Text = item.skill_name, Value = item.id.ToString() });
                }



                ViewBag.skills = skillItem;

                var jobtypes = _context.job_types.ToList();

                List<SelectListItem> ObjItem = new List<SelectListItem>();

                foreach (var item in jobtypes)
                {
                    ObjItem.Add(new SelectListItem() { Text = item.job_type1, Value = item.id.ToString() }); 
                }

                ViewBag.jobtype = ObjItem;
           
                var companyname = _context.companies.ToList();

                List<SelectListItem> Objcompany = new List<SelectListItem>();

                foreach (var item in companyname)
                {
                    Objcompany.Add(new SelectListItem() { Text = item.company_name, Value = item.id.ToString() });
                }
                ViewBag.company = Objcompany;
                int userid = (int)Session["UserId"];
                var locationname = _context.job_locations.Where(c=>c.user_account_id==userid).ToList();

                List<SelectListItem> Objlocation = new List<SelectListItem>();

                foreach (var item in locationname)
                {
                    Objlocation.Add(new SelectListItem() { Text = item.city, Value = item.id.ToString() });
                }
                ViewBag.location = Objlocation;
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

        public ActionResult Jobpost(provider jobpostobj)
        {
            jobpostobj.created_date = DateTime.Now;
            jobpostobj.is_active = true;
            var userid = (int)Session["UserId"];
            if (ModelState.IsValid)
            {

                var jobPost = new job_post();
                //jobPost.posted_by_id = jobpostobj.posted_by_id;
                jobPost.posted_by_id = (int)Session["UserId"];
                jobPost.job_type_id = jobpostobj.job_type_id;
                //jobPost.job = jobpostobj.job;
                //jobPost.job = jobpostobj.job;
                jobPost.company_id = jobpostobj.company_id;
                jobPost.created_date = jobpostobj.created_date;
                jobPost.end_date = jobpostobj.end_date;
                jobPost.job_description = jobpostobj.job_description;
                jobPost.job_location_id = jobpostobj.job_location_id;
                jobPost.min_salary = jobpostobj.min_salary;
                jobPost.max_salary = jobpostobj.max_salary;
                jobPost.is_active = jobpostobj.is_active;
                //_context.job_posts.InsertOnSubmit(jobPost);
                _context.add_job_post(userid, jobpostobj.job_type_id, jobpostobj.company_id, jobpostobj.created_date, jobpostobj.end_date, jobpostobj.job_description,
                jobpostobj.job_location_id, jobpostobj.is_active, jobpostobj.min_salary, jobpostobj.max_salary, jobpostobj.skill_id, 0);
                _context.SubmitChanges();
                return RedirectToAction("Index", "Employer");

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
                companyDetails.user_account_id = (int)Session["UserId"];
                companyDetails.company_name = companyobj.company_name;
                companyDetails.profile_description = companyobj.profile_description;
                companyDetails.business_stream_id = companyobj.business_stream_id;
                companyDetails.establishment_date = companyobj.establishment_date;
                companyDetails.company_website_url = companyobj.company_website_url;
                //companyDetails.user_account_id = companyobj.user_account_id;
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
            return RedirectToAction("Index", "Applicant");
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
            if (ModelState.IsValid)
            {
                var joblocation = new job_location();
            joblocation.street_address = locationobj.street_address;
            joblocation.city = locationobj.city;
            joblocation.state = locationobj.state;
            joblocation.country = locationobj.country;
            joblocation.zip = locationobj.zip;
            joblocation.user_account_id = (int)Session["UserId"];
            _context.job_locations.InsertOnSubmit(joblocation);
            _context.SubmitChanges();
            return RedirectToAction("CompanyModel", "Employer");
            }
            else
            {
                return View();
            }
            if (ModelState.IsValid)
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
            else
            {
                return View();
            }


        }
        //public ActionResult CompanyImage()
        //{
        //    return View();
        //}

    }
}