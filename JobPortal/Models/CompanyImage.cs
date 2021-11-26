using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class CompanyImage
    {
        public int id { get; set; }
        
        [Display(Name = "Company Id")]
        public int company_id { get; set; }
       
        [Display(Name = "Company Image")]
        public string company_image { get; set; }
    }
}