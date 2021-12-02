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
        [StringLength(maximumLength:1000)]
        public string job_description { get; set; }

        [Display(Name = "Company Name")]
        [StringLength(maximumLength:100)]
        public string company_name { get; set; }

        [Display(Name = "City")]
        [StringLength(maximumLength: 50)]
        public string city { get; set; }

        [Display(Name = "State")]
        [StringLength(maximumLength:50)]
        public string state { get; set; }


        [Display(Name = "Skill Level")]
        public int skill_level { get; set; }

        [Display(Name = "Skill name")]
        [StringLength(maximumLength:255)]
        public string skill_name { get; set; }

        [Display(Name = "Job Type")]
        [StringLength(maximumLength:50)]
        public string job_type { get; set; }

        
        [Display (Name = "Applied On")]
        [DataType(DataType.Date)]
        public DateTime apply_date { get; set; }

        public int job_post_id { get; set; }
    }
}