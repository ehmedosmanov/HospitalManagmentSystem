using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalFinalProject.Helpers
{
    public class TimeSlotTimeValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime inputValue)
            {
                var fromProp = validationContext.ObjectType.GetProperty("From");
                var toProp = validationContext.ObjectType.GetProperty("To");

                if (fromProp != null && toProp != null)
                {
                    var fromValue = (DateTime?)fromProp.GetValue(validationContext.ObjectInstance);
                    var toValue = (DateTime?)toProp.GetValue(validationContext.ObjectInstance);

                    if (fromValue >= toValue)
                    {
                        return new ValidationResult(ErrorMessage);
                    }
                }

                DateTime currentDate = DateTime.Now.Date;

                if (inputValue < currentDate)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
