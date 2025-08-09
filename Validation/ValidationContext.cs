using System.Collections.Immutable;

namespace Barone.Blazor.Validation;

/// <summary>
/// Represents the context for validation operations.
/// </summary>
public class ValidationContext : IValidatable
{
    readonly List<ValidationPair> _validationPairs = [];
    internal ValidationPair this[int index] => _validationPairs[index];

    /// <summary>
    /// Gets the number of validation targets in the context.
    /// </summary>
    public int Count => _validationPairs.Count;

    /// <summary>
    /// Adds a validation target to the context.
    /// </summary>
    /// <param name="validatable">The validatable object.</param>
    /// <param name="validator">The validator for the validatable object.</param>
    /// <returns>Index of the added item.</returns>
    public int AddItem(IValidatable validatable, IValidator<IValidatable> validator)
    {
        ArgumentNullException.ThrowIfNull(validatable, nameof(validatable));
        ArgumentNullException.ThrowIfNull(validator, nameof(validator));

        _validationPairs.Add(new ValidationPair(validatable, validator));
        return Count - 1;
    }

    /// <summary>
    /// Gets the validation result for a specific item.
    /// </summary>
    /// <param name="index">The index of the item.</param>
    /// <returns>The validation result.</returns>
    public (bool IsValid, ImmutableArray<string> Errors) GetValidationResult(int index)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, Count, nameof(index));
        ValidationResult result = _validationPairs[index].Validator.Validate(_validationPairs[index].Validatable);
        return (result.IsValid, result.Errors);
    }
}
