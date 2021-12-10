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
        [StringLength(255,ErrorMessage ="Cannot have more than 255 characters")]
        public string first_name { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(255, ErrorMessage = "Cannot have more than 255 characters")]
        public string last_name { get; set; }

        [Required]
        [Display(Name = "Gender")]
        [StringLength(10, ErrorMessage = "Cannot have more than 10 characters")]
        public string gender { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime date_of_birth { get; set; }


    }
}