using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Validation_Project.CustomValidation
{
    public class DobMatch : ValidationAttribute
    {




        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value!=null)
            {
                DateTime input = (DateTime)value;
                int age = DateTime.Now.Year - input.Year;

                // Check if the user is at least the minimum age
                if (age < 18)
                {
                    return new ValidationResult($"You must be at least 18 years old.");
                }
            }


            return ValidationResult.Success;
        }
    }
}