using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class SeekerExperienceModel
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Company name")]
        [StringLength(maximumLength:255,ErrorMessage ="Cannot have more than 255 characters")]
        public string company_name { get; set; }

        [Required]
        [StringLength(maximumLength: 255, ErrorMessage = "Cannot have more than 255 characters")]
        [Display(Name = "Job title")]
        public string job_title { get; set; }

        [Required]
        [StringLength(maximumLength: 500, ErrorMessage = "Cannot have more than 500 characters")]
        [Display(Name = "Job Description")]
        public string job_description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start date")]
        public DateTime start_date { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End date")]
        public DateTime end_date { get; set; }

        [Required]        
        [Display(Name = "Job location: Country")]
        public string job_location_country { get; set; }

        [Required]
        [Display(Name = "Job location: State")]
        public string job_location_state { get; set; }

        [Required]
        [Display(Name = "Job location: City")]
        public string job_location_city { get; set; }

        [Required]
        [Display(Name = "Are you currently working")]
        public Boolean currently_working { get; set; }
    }
}