using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class provider
    {
        internal string company_name;

        public int id { get; set; }

        [Required(ErrorMessage = "Enter Your Posted id")]
        [Display(Name = "Posted Id")]
        public int posted_by_id { get; set; }

        [Required(ErrorMessage = "Enter Your Job type")]
        [Display(Name = "Jobtype")]
        public int job_type_id { get; set; }

        [Required(ErrorMessage = "Enter Your Company")]
        [Display(Name = "Company")]
        public int company_id { get; set; }

        [Required(ErrorMessage = "Enter Your Created date")]
        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime created_date { get; set; }

        [Required(ErrorMessage = "Enter Your Job description")]
        [Display(Name = "Job Description")]
        public string job_description { get; set; }

        [Required(ErrorMessage = "Enter Your Job location id")]
        [Display(Name = "Joblocation")]
        public int job_location_id { get; set; }

        [Display(Name = "Is active")]
        public char is_active { get; set; }
    }
}