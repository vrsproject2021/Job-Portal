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
        internal string job;
        //internal object job;

        public int id { get; set; }

        [Required(ErrorMessage = "Enter Your Posted id")]
        [Display(Name = "Posted Id")]
        public int posted_by_id { get; set; }

        [Required(ErrorMessage = "Enter Your Job type")]
        [Display(Name = "Jobtype")]

        public string Job { get; set; }
        public int job_type_id { get; set; }

        //public string Job { get; set; }

        [Required(ErrorMessage = "Enter Your Company")]
        [Display(Name = "Company")]
        public int company_id { get; set; }

        [Required(ErrorMessage = "Enter Your Created date")]
        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime created_date { get; set; }

        [Required(ErrorMessage = "Enter Your Created date")]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime end_date { get; set; }


        [Required(ErrorMessage = "Enter Your Job description")]
        [Display(Name = "Job Description")]

        [MinLength(1)]
        [MaxLength(500, ErrorMessage = "Exceeds character limits")]
        public string job_description { get; set; }
        [MinLength(1)]
        [MaxLength(500,ErrorMessage ="Exceeds character limits")]
        [Required(ErrorMessage = "Enter Your Job location id")]
        [Display(Name = "Joblocation")]
        public int job_location_id { get; set; }

        [Display(Name = "Minimum Salary")]
        public int min_salary { get; set; }
        
        [Display(Name = "Maximum Salary")]
        public int max_salary { get; set; }

        [Display(Name = "Is active")]
        public Boolean is_active { get; set; }
    }
}