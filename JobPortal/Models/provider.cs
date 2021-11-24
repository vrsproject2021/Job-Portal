using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class provider
    {

        public int id { get; set; }


        [Display(Name = "Posted Id")]
        public int posted_by_id { get; set; }

        [Display(Name = "Jobtype")]
        public int job_type_id { get; set; }

        [Display(Name = "Company")]
        public int company_id { get; set; }

        [Display(Name = "Created Date")]
        public int created_date { get; set; }

        [Display(Name = "Job Description")]
        public string job_description { get; set; }

        [Display(Name = "Joblocation")]
        public int job_location_id { get; set; }

        [Display(Name = "Is active")]
        public int is_active { get; set; }
    }
}