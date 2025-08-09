namespace Barone.Blazor;

public interface IValidationSource
{
    event Action ValidationStateChanged;
}
