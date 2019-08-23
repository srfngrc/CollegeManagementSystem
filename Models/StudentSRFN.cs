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
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //[Required(ErrorMessage = "Please tell us your birth date")]
        //[Range(typeof(DateTime), "1/1/1900", "12/31/2010",ErrorMessage = "{0} must be between {1} and {2}")]
        public DateTime BirthDate { get; set; }
        public string EmailAddr { get; set; }
        public string Country { get; set; }

    }
}