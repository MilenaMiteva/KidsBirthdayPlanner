using System.ComponentModel.DataAnnotations;

public class DateAfterAttribute : ValidationAttribute
{
    private readonly DateTime minDate;

    public DateAfterAttribute(string date)
    {
        if (!DateTime.TryParse(date, out minDate))
        {
            throw new ArgumentException("Invalid date format");
        }
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateTime date)
        {
            if (date < minDate)
            {
                return new ValidationResult(ErrorMessage);
            }
        }

        return ValidationResult.Success;
    }
}
