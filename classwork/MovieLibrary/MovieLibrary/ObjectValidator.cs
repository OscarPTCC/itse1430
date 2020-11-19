using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieLibrary
{
    //Static class
    // 1. Cannot be instantiated
    // 2. Cannot contain instance members
    public static class ObjectValidator
    {
        public static IEnumerable<ValidationResult> TryValidateFullObject ( IValidatableObject value)
        {
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(value, new ValidationContext(value), validationResults, true);

            return validationResults;
        }

        public static void ValidateFullObject ( IValidatableObject value )
        {
            Validator.ValidateObject(value, new ValidationContext(value), true);
        }
    }
}
