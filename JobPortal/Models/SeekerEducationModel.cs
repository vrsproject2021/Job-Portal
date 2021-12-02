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
        [StringLength(maximumLength:100,ErrorMessage ="Cannot have more than 100 characters")]
        [Display(Name = "Certification or Degree Name")]

        public string certificate_degree_name { get; set; }

        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Cannot have more than 100 characters")]
        [Display(Name ="Stream")]
        public string major { get; set; }

        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Cannot have more than 100 characters")]
        [Display(Name ="University")]
        public string university_institute_name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        //[Display(Name = "Start date")]
        //public DateTime start_date { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yy}")]
        public DateTime? start_date { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime end_date { get; set; }

        [Required]
        [StringLength(maximumLength: 10, ErrorMessage = "Cannot have more than 10 characters")]
        [Display(Name = "CGPA or Percentage")]
        public string cgpa_percentage { get; set; }
    }
}