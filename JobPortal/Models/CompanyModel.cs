using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class CompanyModel
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Enter Your Company Name")]
        [Display(Name = "Company Name")]
       
        public string company_name { get; set; }

        [Required(ErrorMessage = "Enter Your Profile Description")]
        [Display(Name = "Profile Description")]
        public string profile_description { get; set; }

        //[Required(ErrorMessage = "Enter Your Business Stream")]
        [Display(Name = "Business Stream")]
        public int business_stream_id { get; set; }

        [Required(ErrorMessage = "Enter Your Establishment Date")]
        [DataType(DataType.Date)]
        [Display(Name = "Establishment Date")]
        public DateTime establishment_date { get; set; }

        [Required(ErrorMessage = "Enter Your Website")]
        [Display(Name = "Website")]
        public string company_website_url { get; set; }
    }
}