using JobPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace JobPortal.Controllers
{
    public class AdminController : Controller
    {
        private DBOperationDataContext _context;

        public AdminController()
        {
            _context = new DBOperationDataContext();
        }
        //DataClasses1DataContext dc = new DataClasses1DataContext();
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.TotalUsers = _context.user_accounts.Count();
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



        public ActionResult Users()
        {
            var userdetails = from x in _context.user_accounts select x ;
            return View(userdetails);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var getuserdetails = _context.user_accounts.Single(x => x.id == id);
                return View(getuserdetails);
            }
         
            catch
            {
                return View();
            }
        }


        public ActionResult alluserDetails(int id)
        {
            try
            {
                var getalluserdetails = _context.seeker_profiles.SingleOrDefault(x => x.user_account_id == id);
                return View(getalluserdetails);
            }
            catch
            {
                return View();
            }
            
        }


        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            var getuserdetails = _context.user_accounts.Single(x => x.id == id);
            return View(getuserdetails);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, user_account collection)
        {
            try
            {
                // TODO: Add update logic here
                var userupdate = _context.user_accounts.Single(x => x.id == id);
                userupdate.id = collection.id;
                userupdate.email_id = collection.email_id;
                userupdate.password = collection.password;
                userupdate.phone_number = collection.phone_number;
                userupdate.user_type = collection.user_type;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {

            var getuserdetails = _context.user_accounts.Single(x => x.id == id);
            return View(getuserdetails);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, user_account collection)
        {
            try
            {
                // TODO: Add delete logic here
                var expdel = _context.seeker_experiences.Single(x => x.user_account_id == id);
            var edudel = _context.seeker_educations.Single(x => x.user_account_id == id);
            var profdel = _context.seeker_profiles.Single(x => x.user_account_id == id);
            var userdel = _context.user_accounts.Single(x => x.id == id);       
                
            _context.seeker_experiences.DeleteOnSubmit(expdel);
            _context.seeker_educations.DeleteOnSubmit(edudel);
            _context.seeker_profiles.DeleteOnSubmit(profdel);
            _context.user_accounts.DeleteOnSubmit(userdel);
                
                 _context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Candidatetable()
        {
            var candidatetable = from x in _context.seeker_profiles select x;
            return View(candidatetable);            
        }


        public ActionResult CandidateDetails(int id)
        {
            var getcandidatedetails = _context.seeker_educations.Single(x => x.user_account_id== id);
            return View(getcandidatedetails);
        }


        public ActionResult ExperienceDetails(int id)
        {
            var getexperiencedetails = _context.seeker_experiences.Single(x => x.user_account_id == id);
            return View(getexperiencedetails);
        }



        public ActionResult Company()
        {
            var companydetails = from x in _context.companies select x;
            return View(companydetails);         

        }


        public ActionResult CompanyDetails(int id)
        {
            var getcompanydetails = _context.companies.Single(x => x.id == id);
            return View(getcompanydetails);
        }




        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email_id, string password)
        {
            password = encrypt(password);
            if (ModelState.IsValid)
            {
                var loginDetails = _context.user_accounts.Where(u => u.email_id == email_id && u.password == password && u.user_type == "Admin").FirstOrDefault();
                if (loginDetails != null)
                {
                    Session["User"] = loginDetails.email_id;
                    Session["UserId"] = loginDetails.id;

                    return RedirectToAction("Index", "Admin");
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
                newUser.user_type = "Admin";
                _context.user_accounts.InsertOnSubmit(newUser);
                _context.SubmitChanges();
                TempData["Message"] = "Successfully Registered";
                return RedirectToAction("Login", "Admin");

            }

            return View();
        }

        public ActionResult LOGOUT()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Admin");
            
        }



    }
}
