using JobPortal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;

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
        #region Login
        public ActionResult Login() 
        {
            return View();
        }
        //public string encrypt(string clearText)
        //{
        //    string EncryptionKey = "MAKV2SPBNI99212";
        //    byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        //    using (Aes encryptor = Aes.Create())
        //    {
        //        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
        //        encryptor.Key = pdb.GetBytes(32);
        //        encryptor.IV = pdb.GetBytes(16);
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
        //            {
        //                cs.Write(clearBytes, 0, clearBytes.Length);
        //                cs.Close();
        //            }
        //            clearText = Convert.ToBase64String(ms.ToArray());
        //        }
        //    }
        //    return clearText;
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email_id, string password)
        {
            //password = encrypt(password);
            if (ModelState.IsValid)
            {

                
                var loginDetails = _context.user_accounts.Where(u => u.email_id == email_id ).FirstOrDefault();
                var passwordIsCorrect = Crypto.VerifyHashedPassword(loginDetails.password,password);
                if (loginDetails != null && passwordIsCorrect == true)
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
        #endregion

        #region Registration
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
                newUser.password = Crypto.HashPassword(newuserobj.password);
                newUser.phone_number = newuserobj.phone_number;
                newUser.user_type = "jobseeker";
                _context.user_accounts.InsertOnSubmit(newUser);
                _context.SubmitChanges();
                return RedirectToAction("Login","Applicant");
            
            }

            return View(); 
        }
        #endregion

        #region Applicant Details
        public ActionResult Details() 
        {
            
            if (Session["UserId"] != null)
            {
                int userId = (int)Session["UserId"];
                ViewBag.Profile = _context.seeker_profiles.Where(u => u.user_account_id == userId).FirstOrDefault();
                ViewBag.Education = _context.seeker_educations.Where(u => u.user_account_id == userId).FirstOrDefault();
                ViewBag.Experience = _context.seeker_experiences.Where(u => u.user_account_id == userId).FirstOrDefault();
                ViewBag.Skills = _context.get_seeker_skills(userId);

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Applicant");
            }
        }
        #endregion

        #region 
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
        #endregion

        #region Education
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
                newEducation.start_date = (DateTime)newSeekerObj.start_date;
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
                    newEducation.start_date = (DateTime)newSeekerObj.start_date;
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
        #endregion

        #region Experience
        public ActionResult Experience()
        {
            if (Session["UserId"] != null)
            {

                var editableExperience = new SeekerExperienceModel { currently_working = true };
                return View(editableExperience);
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
        #endregion

        #region Skill

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult AddSkill(SkillModel skillObj)
        {
            if (ModelState.IsValid)
            {
                if (Session["userId"] != null)
                {
                    int userId = (int)Session["UserId"];
     
                    _context.add_seeker_skill(userId, skillObj.skill_name,skillObj.skill_experience );
                    return RedirectToAction("Details", "Applicant");
                }
                else
                {
                    return RedirectToAction("Login", "Applicant");
                }
            }
            else 
            {
                return RedirectToAction("Details", "Applicant");
            }
        }
        [HttpPost]
        public ActionResult DeleteSkill(string skill_name) 
        {
            if (Session["userId"] != null)
            {
                int userId = (int)Session["UserId"];

                _context.delete_seeker_skill(userId, skill_name);
                return RedirectToAction("Details", "Applicant");
            }
            else
            { 
                return RedirectToAction("Login", "Applicant"); 
            }
        }
        #endregion

        #region Applied Jobs
        public ActionResult AppliedJobs()
        {

            IList<AppliedJobModel> appliedJobsList = new List<AppliedJobModel>();


            if (Session["UserId"] != null)
            {
                try
                {

                    var appliedJobs = _context.get_applied_jobs((int)Session["UserId"]);
                   
                        foreach (var appliedJob in appliedJobs.ToList())
                        {
                            appliedJobsList.Add(new AppliedJobModel()
                            {
                                job_description = appliedJob.job_description,
                                company_name = appliedJob.company_name,
                                city = appliedJob.city,
                                state = appliedJob.state,
                                skill_level = appliedJob.skill_level,
                                skill_name = appliedJob.skill_name,
                                job_type = appliedJob.job_type,
                                apply_date = (DateTime)appliedJob.apply_date,
                                job_post_id = appliedJob.job_post_id

                            }); ;
                        }
                return View(appliedJobsList);
                   }
                catch
                {
                    return View("Error");
                }
            }
            else
            {
                return RedirectToAction("Login", "Applicant");
            }
        }

        [HttpPost]
        public ActionResult DeleteAppliedJob (string jobId)
        {
            if (Session["UserId"] != null)

            {
                var jobactivity = _context.job_post_activities.Where(u => u.user_account_id == (int)Session["UserId"] && u.job_post_id == int.Parse(jobId)).FirstOrDefault();
                _context.job_post_activities.DeleteOnSubmit(jobactivity);
                _context.SubmitChanges();

                return RedirectToAction("AppliedJobs", "Applicant");
            }
            else
            {
                return View("Login","Applicant");
            }
        }
        #endregion

        #region Search Jobs
        [HttpPost]
        public ActionResult Index(string skill,string location )
        {
            IList<AvailableJobModel> availableJobsList = new List<AvailableJobModel>();


            try
            {

                var availableJobs = _context.search_for_jobs(skill, location);

                foreach (var availableJob in availableJobs)
                {
                    availableJobsList.Add(new AvailableJobModel()
                    {
                        job_description = availableJob.job_description,
                        company_name = availableJob.company_name,
                        city = availableJob.city,
                        state = availableJob.state,
                        skill_level = availableJob.skill_level,
                        skill_name = availableJob.skill_name,
                        job_type = availableJob.job_type,
                        job_post_id = availableJob.id

                    }); ;
                }
            }
            catch
            {
                return View("Error");
            }

            
            return View(availableJobsList);
        }
        #endregion



        public ActionResult availablejobIndex(string skill, string location)
        {
            IList<AvailableJobModel> availableJobsList = new List<AvailableJobModel>();


            try
            {

                var availableJobs = _context.search_for_jobs(skill, location);

                foreach (var availableJob in availableJobs)
                {
                    availableJobsList.Add(new AvailableJobModel()
                    {
                        job_description = availableJob.job_description,
                        company_name = availableJob.company_name,
                        city = availableJob.city,
                        state = availableJob.state,
                        skill_level = availableJob.skill_level,
                        skill_name = availableJob.skill_name,
                        job_type = availableJob.job_type,
                        job_post_id = availableJob.id

                    }); ;
                }
            }
            catch
            {
                return View("Error");
            }


            return View(availableJobsList);
        }








        #region Apply for Jobs

        [HttpPost]
        public ActionResult ApplyForJob(String jobId)
        {

            if (Session["UserId"] != null)
            {
                job_post_activity appliedjob = new job_post_activity();
                appliedjob.user_account_id = (int)Session["UserId"];
                appliedjob.job_post_id = int.Parse(jobId);
                appliedjob.apply_date = DateTime.Now;
                _context.job_post_activities.InsertOnSubmit(appliedjob);
                try
                {
                    _context.SubmitChanges();
                }
                catch
                {
                    return View("Error");
                }
                return RedirectToAction("AppliedJobs", "Applicant");
            }
            else 
            {
                return RedirectToAction("Login", "Applicant");
            }
        }
        #endregion

        #region Logout
        public ActionResult LOGOUT()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Applicant");
        }
        #endregion

    }
}