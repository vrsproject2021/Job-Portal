using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class SkillModel
    {

        
        [Required]
        public string skill_name { get; set; }

        [Required]
        public int skill_experience { get; set; }
    }
}