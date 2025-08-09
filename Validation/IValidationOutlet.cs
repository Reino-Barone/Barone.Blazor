namespace Barone.Blazor.Validation;

public interface IValidationOutlet
{
    bool IsValid { get; set; }
    IEnumerable<string> Messages { get; }
    void OutputMessages(IEnumerable<string> messages);
}
