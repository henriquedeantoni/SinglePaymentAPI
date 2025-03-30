using System.ComponentModel.DataAnnotations;

namespace SinglePaymentAPI.Utils;

public class SsnOrEinValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext vaalidationContext)
    {
        var ssnOrEin = value as string;

        if (string.IsNullOrEmpty(ssnOrEin) || !SSNEINValidator.IsValidSsnEin(ssnOrEin))
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}
