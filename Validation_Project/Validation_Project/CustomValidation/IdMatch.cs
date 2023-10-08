using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Validation_Project.CustomValidation
{
    public class IdMatch : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string input = value.ToString();



                if (!Regex.IsMatch(input, @"^\d{2}-\d{5}-\d$"))
                {
                    return new ValidationResult("The input must follow the pattern xx-xxxxx-x, and each x should be an integer.");
                }
            }



            return ValidationResult.Success;
        }
    }
}