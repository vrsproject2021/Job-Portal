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
        [Display(Name ="Skill Name")]
        public string skill_name { get; set; }

        [Required]
        [Display (Name = "Experience")]
        public int skill_experience { get; set; }
    }
}