using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollegeManagementSystem.Models
{
    public class StudentSRFN
    {
        public int StudentId { get; set; }

        //[Display(Name = "What is your First Name?")]
        [Required(ErrorMessage = "Please tell us what is your First Name")]
        public string FirstName { get; set; }

        //[Display(Name = "What is your Last Name?")]
        [Required(ErrorMessage = "Please tell us what is your Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please tell us your birth date")]
        //[Range(typeof(DateTime), "1/1/1900", "12/31/2010",ErrorMessage = "{0} must be between {1} and {2}")]
        public DateTime BirthDate { get; set; }

        //[Display(Name = "What is your email address?")]
        [Required(ErrorMessage = "Please tell us what is your email address")]
        public string EmailAddr { get; set; }

        //[Display(Name = "In what country do you live most of the year?")]
        [Required(ErrorMessage = "Please tell us where is your usual residency")]
        public string Country { get; set; }

    }
}