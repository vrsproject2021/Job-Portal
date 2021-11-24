using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Models
{
    public class SeekerEducationModel
    {
        [Key]
        public int id {get;set;}

        [Required]
        [Display(Name = "Certification or Degree Name")]

        public string certificate_degree_name { get; set; }

        [Required]
        [Display(Name ="Stream")]
        public string major { get; set; }

        [Required]
        [Display(Name ="University")]
        public string university_institute_name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start date")]
        public DateTime start_date { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime end_date { get; set; }

        [Required]
        [Display(Name = "CGPA or Percentage")]
        public string cgpa_percentage { get; set; }
    }
}