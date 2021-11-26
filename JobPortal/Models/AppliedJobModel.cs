using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class AppliedJobModel
    {
        [Display(Name ="Job Description" )]
        public string job_description { get; set; }

        [Display(Name = "Company Name")]
        public string company_name { get; set; }

        [Display(Name = "City")]
        public string city { get; set; }

        [Display(Name = "State")]
        public string state { get; set; }

        [Display(Name = "Skill Level")]
        public int skill_level { get; set; }

        [Display(Name = "Skill name")]
        public string skill_name { get; set; }

        [Display(Name = "Job Type")]
        public string job_type { get; set; }
        [Display (Name = "Applied On")]
        public DateTime apply_date { get; set; }
    }
}