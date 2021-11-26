using JobPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            
            return View();
           
        }


        public ActionResult Users()
        {
            var userdetails = from x in _context.user_accounts select x ;
            return View(userdetails);

        }



        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            var getuserdetails = _context.user_accounts.Single(x => x.id == id);
            return View(getuserdetails);
        }

        // GET: Admin/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Admin/Create
        //[HttpPost]
        //public ActionResult Create(user_account collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here
        //        dc.user_accounts.InsertOnSubmit(collection);
        //        dc.SubmitChanges();
        //        return RedirectToAction("Index");
               
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

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
                var userdel = _context.user_accounts.Single(x => x.id == id);
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












    }
}
