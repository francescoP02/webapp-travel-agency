using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Validation
{
    public class NegativeOrZero : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            float fieldValue = (float)value;
            if (fieldValue <= 0)
            {
                return new ValidationResult("Il numero non puo essere minore o uguale a zero");
            }
            return ValidationResult.Success;
        }
    }
}
