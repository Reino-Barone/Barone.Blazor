namespace Barone.Blazor.Validation;

public interface IValidator<TValidatable> where TValidatable : IValidatable
{
    bool Validate(TValidatable validatable);
}
