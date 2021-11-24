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
                var newUser = new user_account();
                newUser.email_id = newuserobj.email_id;
                newUser.password = newuserobj.password;
                newUser.phone_number = newuserobj.phone_number;
                newUser.user_type = "jobseeker";
                _context.user_accounts.InsertOnSubmit(newUser);
                _context.SubmitChanges();
                return RedirectToAction("Login","Applicant");
            
            }

            return View(); 
        }

        public ActionResult Details() 
        {
            if (Session["UserId"] != null)
            {
                ViewBag.Profile = _context.seeker_profiles.Where(u => u.user_account_id == (int)Session["UserId"]).FirstOrDefault();
                ViewBag.Education = _context.seeker_educations.Where(u => u.user_account_id == (int)Session["UserId"]).FirstOrDefault();
                ViewBag.Experience = _context.seeker_experiences.Where(u => u.user_account_id == (int)Session["UserId"]).FirstOrDefault();

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Applicant");
            }
        }
        public ActionResult Profile()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Applicant");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Profile(SeekerProfileModel newSeekerObj)
        {
            if (ModelState.IsValid)
            {
                var newProfile = new seeker_profile();
                newProfile.user_account_id = (int)Session["UserId"];
                newProfile.first_name= newSeekerObj.first_name;
                newProfile.last_name = newSeekerObj.last_name ;
                newProfile.gender = newSeekerObj.gender ;                
                newProfile.date_of_birth = newSeekerObj.date_of_birth;
                _context.seeker_profiles.InsertOnSubmit(newProfile);
                _context.SubmitChanges();

                var education = _context.seeker_educations.Where(u => u.user_account_id == (int)Session["UserId"]).FirstOrDefault();
                if (education == null)
                {
                    return RedirectToAction("Education", "Applicant");
                }
                else 
                {
                    return RedirectToAction("Details", "Applicant");
                }
                

            }
            return View();
        }

        public ActionResult EditProfile()
        {

            var profile = _context.seeker_profiles.Where(u => u.user_account_id == (int)Session["UserId"]).FirstOrDefault();
            var editableProfile = new SeekerProfileModel
            {
                first_name = profile.first_name,
                last_name = profile.last_name,
                gender = profile.gender,
                date_of_birth = profile.date_of_birth


            };
            return View(editableProfile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult EditProfile(SeekerProfileModel newSeekerObj)
        {
            if (ModelState.IsValid)
            {
                var profile = _context.seeker_educations.Where(u => u.user_account_id == (int)Session["UserId"]).FirstOrDefault();
                if (profile != null)
                {
                    var newProfile = new seeker_profile();
                    newProfile.user_account_id = (int)Session["UserId"];
                    newProfile.first_name = newSeekerObj.first_name;
                    newProfile.last_name = newSeekerObj.last_name;
                    newProfile.gender = newSeekerObj.gender;
                    newProfile.date_of_birth = newSeekerObj.date_of_birth;
                    _context.SubmitChanges();
                }
                return RedirectToAction("Details", "Applicant");

            }
            return View();
        }

        public ActionResult DeleteProfile()
        {
            var profile = _context.seeker_profiles.Where(u => u.user_account_id == (int)Session["UserId"]).FirstOrDefault();
            _context.seeker_profiles.DeleteOnSubmit(profile);
            _context.SubmitChanges();
            return RedirectToAction("Details", "Applicant");
        }



        public ActionResult Education()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Applicant");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Education(SeekerEducationModel newSeekerObj)
        {
            if (ModelState.IsValid)
            {
                var newEducation = new seeker_education();
                newEducation.user_account_id = (int)Session["UserId"];
                newEducation.certificate_degree_name = newSeekerObj.certificate_degree_name;
                newEducation.major = newSeekerObj.major;
                newEducation.university_institute_name = newSeekerObj.university_institute_name;
                newEducation.start_date = newSeekerObj.start_date;
                newEducation.end_date = newSeekerObj.end_date;
                newEducation.cgpa_percentage = newSeekerObj.cgpa_percentage;

                _context.seeker_educations.InsertOnSubmit(newEducation);
                _context.SubmitChanges();

                var experience = _context.seeker_experiences.Where(u => u.user_account_id == (int)Session["UserId"]).FirstOrDefault();
                if (experience == null)
                {
                    return RedirectToAction("Experience", "Applicant");
                }
                else 
                {
                    return RedirectToAction("Details", "Applicant");
                }
                

            }
            return View();
        }

        public ActionResult EditEducation()
        {

            var education = _context.seeker_educations.Where(u => u.user_account_id == (int)Session["UserId"]).FirstOrDefault();
            var editableEducation = new SeekerEducationModel 
            { 
                certificate_degree_name = education.certificate_degree_name,
                major = education.major,
                university_institute_name = education.university_institute_name,
                start_date = education.start_date,
                end_date = (DateTime)education.end_date,
                cgpa_percentage = education.cgpa_percentage


            };
            return View(editableEducation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult EditEducation(SeekerEducationModel newSeekerObj)
        {
            if (ModelState.IsValid)
            {
                var education = _context.seeker_educations.Where(u => u.user_account_id == (int)Session["UserId"]).FirstOrDefault();
                if (education != null)
                {
                    var newEducation = new seeker_education();
                    newEducation.user_account_id = (int)Session["UserId"];
                    newEducation.certificate_degree_name = newSeekerObj.certificate_degree_name;
                    newEducation.major = newSeekerObj.major;
                    newEducation.university_institute_name = newSeekerObj.university_institute_name;
                    newEducation.start_date = newSeekerObj.start_date;
                    newEducation.end_date = newSeekerObj.end_date;
                    newEducation.cgpa_percentage = newSeekerObj.cgpa_percentage;
                    _context.SubmitChanges();
                }
                return RedirectToAction("Details", "Applicant");

            }
            else
            {
                return View();
            }
            
        }

        public ActionResult DeleteEducation() 
        {
            var education = _context.seeker_educations.Where(u => u.user_account_id == (int)Session["UserId"]).FirstOrDefault();
            _context.seeker_educations.DeleteOnSubmit(education);
            _context.SubmitChanges();
            return RedirectToAction("Details", "Applicant");
        }



        public ActionResult Experience()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Applicant");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Experience(SeekerExperienceModel newSeekerObj)
        {
            if (ModelState.IsValid)
            {
                var newExperience = new seeker_experience();
                newExperience.user_account_id = (int)Session["UserId"];
                newExperience.company_name = newSeekerObj.company_name;
                newExperience.job_title = newSeekerObj.job_title;
                newExperience.job_description = newSeekerObj.job_description;
                newExperience.start_date = newSeekerObj.start_date;
                newExperience.end_date = newSeekerObj.end_date;
                newExperience.job_location_country = newSeekerObj.job_location_country;
                newExperience.job_location_state = newSeekerObj.job_location_state;
                newExperience.job_location_city = newSeekerObj.job_location_city;
                newExperience.currently_working = newSeekerObj.currently_working;


                _context.seeker_experiences.InsertOnSubmit(newExperience);
                _context.SubmitChanges();
                return RedirectToAction("Index", "Applicant");

            }
            else 
            {
                return View();
            }
            
        }

        public ActionResult EditExperience()
        {

            var experience= _context.seeker_experiences.Where(u => u.user_account_id == (int)Session["UserId"]).FirstOrDefault();
            var editableExperience = new SeekerExperienceModel
            {
                company_name = experience.company_name,
                job_title = experience.job_title,
                job_description = experience.job_description,
                start_date = experience.start_date,
                end_date = (DateTime)experience.end_date,
                job_location_country= experience.job_location_country,
                job_location_state = experience.job_location_state,
                job_location_city = experience.job_location_city,
                currently_working = experience.currently_working



            };
            return View(editableExperience);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult EditExperience(SeekerExperienceModel newSeekerObj)
        {
            if (ModelState.IsValid)
            {
                var experience = _context.seeker_experiences.Where(u => u.user_account_id == (int)Session["UserId"]).FirstOrDefault();
                if (experience != null)
                {
                    var newExperience = new seeker_experience();
                    newExperience.user_account_id = (int)Session["UserId"];
                    newExperience.company_name = newSeekerObj.company_name;
                    newExperience.job_title = newSeekerObj.job_title;
                    newExperience.job_description = newSeekerObj.job_description;
                    newExperience.start_date = newSeekerObj.start_date;
                    newExperience.end_date = newSeekerObj.end_date;
                    newExperience.job_location_country = newSeekerObj.job_location_country;
                    newExperience.job_location_state = newSeekerObj.job_location_state;
                    newExperience.job_location_city = newSeekerObj.job_location_city;
                    newExperience.currently_working = newSeekerObj.currently_working;
                    _context.SubmitChanges();
                }
                return RedirectToAction("Details", "Applicant");

            }
            else 
            {
                return View();
            }
            
        }
        public ActionResult DeleteExperience()
        {
            var experience = _context.seeker_experiences.Where(u => u.user_account_id == (int)Session["UserId"]).FirstOrDefault();
            _context.seeker_experiences.DeleteOnSubmit(experience);
            _context.SubmitChanges();
            return RedirectToAction("Details", "Applicant");
        }

        public ActionResult LOGOUT()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

    }
}