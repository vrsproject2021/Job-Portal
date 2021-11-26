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
        
        [Display(Name = "Company Name")]
        public string company_name { get; set; }
        
        [Display(Name = "Profile Description")]
        public string profile_description { get; set; }
        
        [Display(Name = "Business Stream")]
        public int business_stream_id { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Establishment Date")]
        public DateTime establishment_date { get; set; }
        
        [Display(Name = "Company Url")]
        public string company_website_url { get; set; }
    }
}