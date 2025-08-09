namespace Barone.Blazor.Validation;

public record ValidationPair(IValidatable Validatable, IValidator<IValidatable> Validator);
