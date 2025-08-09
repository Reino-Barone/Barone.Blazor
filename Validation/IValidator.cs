namespace Barone.Blazor.Validation;

/// <summary>
/// Defines a contract for validating instances of a specific type.
/// </summary>
/// <typeparam name="TValidatable"></typeparam>
public interface IValidator<TValidatable> where TValidatable : IValidatable
{
    /// <summary>
    /// Validates the specified validatable object.
    /// </summary>
    /// <param name="validatable"></param>
    /// <returns><seealso cref="ValidationResult"/> object.</returns>
    ValidationResult Validate(TValidatable validatable);
}
