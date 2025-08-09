using System.Collections.Immutable;

namespace Barone.Blazor.Validation;

/// <summary>
/// Defines a contract for validating an object.
/// </summary>
public interface IValidatable;

/// <summary>
/// Represents the result of a validation operation.
/// </summary>
/// <param name="IsValid"></param>
/// <param name="Errors"></param>
public record struct ValidationResult(bool IsValid, ImmutableArray<string> Errors);
