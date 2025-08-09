using System.Collections.Immutable;

namespace Barone.Blazor.Validation;

/// <summary>
/// Represents the context for validation operations.
/// </summary>
public class ValidationContext : IValidatable
{
    readonly List<ValidationPair> _validationPairs = [];
    internal ValidationPair this[int index] => _validationPairs[index];
    public int Count => _validationPairs.Count;
    public int AddItem(IValidatable validatable, IValidator<IValidatable> validator)
    {
        ArgumentNullException.ThrowIfNull(validatable, nameof(validatable));
        ArgumentNullException.ThrowIfNull(validator, nameof(validator));
        
        _validationPairs.Add(new ValidationPair(validatable, validator));
        return Count - 1;
    }
}
