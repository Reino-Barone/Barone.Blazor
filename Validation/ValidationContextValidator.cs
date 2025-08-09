using System.Collections.Immutable;

namespace Barone.Blazor.Validation;

/// <summary>
/// Validates a <see cref="ValidationContext"/>.
/// </summary>
public class ValidationContextValidator : IValidator<ValidationContext>
{
    /// <summary>
    /// Validates the specified <see cref="ValidationContext"/>.
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public ValidationResult Validate(ValidationContext context)
    {
        int count = context.Count;
        List<string> errors = new(count);
        bool isValid = true;
        for (int i = 0; i < count; i++)
        {
            ValidationPair pair = context[i];
            ValidationResult result = pair.Validator.Validate(pair.Validatable);
            if (!result.IsValid)
            {
                isValid = false;
                errors.AddRange(result.Errors);
            }
        }

        return new ValidationResult(isValid, [.. errors]);
    }
}
