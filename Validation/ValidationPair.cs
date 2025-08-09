namespace Barone.Blazor.Validation;

internal record ValidationPair(IValidatable Validatable, IValidator<IValidatable> Validator);
