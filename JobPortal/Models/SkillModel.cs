using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class SkillModel
    {
        [Key]
        public int id { get; set; }
        

        [Required(ErrorMessage = "Enter skill name")]
        [StringLength(maximumLength:255)]
        [Display(Name ="Skill Name")]
        public string skill_name { get; set; }

        [Required]
        [Display (Name = "Experience")]
        [Range(0,50,ErrorMessage ="Invalid skill experience")]
        public int skill_experience { get; set; }
    }
}