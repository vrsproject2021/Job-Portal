using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class UserModel
    {
        [Key]
        public int id { get; set; }


        [Required(ErrorMessage = "Enter Your Email Address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid email address")]
        [StringLength(maximumLength:250)]
        [Display(Name = "Email")]
        public string email_id { get; set; }


        [Required(ErrorMessage = "Enter Your Password")]
        [StringLength(maximumLength: 100,ErrorMessage ="Cannot have more than 100 characters")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }


        [Display(Name = "Phone")]
        [RegularExpression(@"((\+*)((0[ -]*)*|((91 )*))((\d{12})+|(\d{10})+))|\d{5}([- ]*)\d{6}", ErrorMessage = "Invalid phone number")]
        [StringLength(maximumLength:15,ErrorMessage ="Exceeds character limit")]
        public string phone_number { get; set; }


        [NotMapped]
        [Required]
        [Display(Name = "Confirm Password")]
        [StringLength(maximumLength: 100,ErrorMessage ="Cannot have more than 100 characters")]

        [DataType(DataType.Password)]

        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public string ConfirmPassword { get; set; }

        [StringLength(maximumLength:30)]
        public string user_type { get; set; }




    }
}