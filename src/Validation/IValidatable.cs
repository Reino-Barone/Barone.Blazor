namespace Barone.Blazor.Validation;

public interface IValidatable
{
    bool IsValid { get; }
    IEnumerable<string> ValidationErrors { get; }
}
