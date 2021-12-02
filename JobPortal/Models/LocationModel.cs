using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class LocationModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Enter Your Street Address")]
        [Display(Name = "Street Address")]
        public string street_address { get; set; }

        [MinLength(10)]
        [MaxLength(100)]
        [Required(ErrorMessage = "Enter Your City")]
        [Display(Name = "City")]
        public string city { get; set; }
        
        [MinLength(10)]
        [MaxLength(100)]
        [Required(ErrorMessage = "Enter Your State")]
        [Display(Name = "State")]
        public string state { get; set; }

        [Required(ErrorMessage = "Enter Your Country")]
        [Display(Name = "Country")]
        public string country { get; set; }

        [Required(ErrorMessage = "Enter Your zip")]
        [Display(Name = "Zip")]
        public string zip { get; set; }
    }
}