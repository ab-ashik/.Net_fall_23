using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Validation_Project.CustomValidation;

namespace Validation_Project.Models
{
    public class SignUp
    {
        [Required(ErrorMessage = "Provide your name")]
        [RegularExpression("^[a-zA-Z]{4,50}$", ErrorMessage = "Only alphabetic characters are allowed, and the length should be between 4 and 50 characters.")]


        public string Name { get; set; }

        [Required(ErrorMessage = "Provide your Username")]
        [RegularExpression("^[A-Za-z0-9\\-_]{4,12}$", ErrorMessage = "Only alphabetic characters, numbers, and dashes are allowed, and the length should be between 4 and 12 characters.")]

        public string Username { get; set; }

        

        [Required(ErrorMessage = "Provide your Password")]
         [RegularExpression("^(?=.*[A-Z])(?=.*[a-z].*[a-z])(?=.*[!@#$%^&*0-9].*[!@#$%^&*0-9])[A-Za-z]{4}[!@#$%^&*0-9]{4,}[A-Za-z0-9\\-_]$", ErrorMessage = "The ERROR")]
       // [RegularExpression("^(?=.*[A-Z])(?=.*[a-z].*[a-z].*[a-z])(?=.*[0-9!@#$%^&*()_+|{}[\\]:;<>,.?~]).{8,}$\r\n", ErrorMessage = "Pass ERROR")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Provide your ID")]
        [IdMatch(ErrorMessage = "ID error")]
        public string Id { get; set; }


        [Required(ErrorMessage = "Provide your Email")]
        [EmailMatch(ErrorMessage = "Email error")]
        public string Email { get; set; }


        ///
        //[DataType(DataType.Date)]
        [Required(ErrorMessage = "Date of Birth is required.")]
        // [Range(typeof(DateTime), "2005-10-08", "2023-10-08", ErrorMessage = "You must be at least 18 years old.")]
        [DobMatch(ErrorMessage = "Dob error")]
        public DateTime Dob { get; set; }



    }

}