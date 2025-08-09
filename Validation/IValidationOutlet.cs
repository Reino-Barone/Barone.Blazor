namespace Barone.Blazor.Validation;

/// <summary>
/// Represents an outlet for validation messages.
/// </summary>
public interface IValidationOutlet
{
    /// <summary>
    /// Gets or sets a value indicating whether the outlet is valid.
    /// </summary>
    bool IsValid { get; set; }

    /// <summary>
    /// Gets the validation messages.
    /// </summary>
    IEnumerable<string> Messages { get; }

    /// <summary>
    /// Outputs the specified validation messages.
    /// </summary>
    /// <param name="messages">The messages to output.</param>
    void OutputMessages(IEnumerable<string> messages);
}
