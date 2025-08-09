namespace Barone.Blazor.Validation;

/// <summary>
/// Represents a source of validation messages.
/// </summary>
public interface IValidationSource
{
    /// <summary>
    /// Occurs when the validation state changes.
    /// </summary>
    event Action ValidationStateChanged;
}
