using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class SeekerProfileModel
    {
        [Key]
        public int id {get;set;}

        [Required]
        [Display(Name ="First Name")]
        public string first_name { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string last_name { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string gender { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime date_of_birth { get; set; }


    }
}