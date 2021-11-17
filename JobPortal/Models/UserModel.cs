using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class UserModel
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Enter Email Address")]
        public string email_id { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        public string password { get; set; }

        public string phone_number { get; set; }

        public string user_type { get; set; }


    }
}