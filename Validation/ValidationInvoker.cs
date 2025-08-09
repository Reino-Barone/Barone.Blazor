namespace Barone.Blazor.Validation;

internal sealed class ValidationInvoker : IDisposable
{
    readonly ValidationContext _context;
    readonly IValidationSource _source;
    readonly IValidationOutlet _outlet;
    static readonly ValidationContextValidator _validator = new();
    bool _disposed = false;
    public ValidationInvoker(ValidationContext context, IValidationSource source, IValidationOutlet outlet)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _source = source ?? throw new ArgumentNullException(nameof(source));
        _outlet = outlet ?? throw new ArgumentNullException(nameof(outlet));

        _source.ValidationStateChanged += Invoke;
    }

    void IDisposable.Dispose()
    {
        if (_disposed) return;

        _source.ValidationStateChanged -= Invoke;
        _disposed = true;
    }

    void Invoke()
    {
        ValidationResult result = _validator.Validate(_context);
        _outlet.IsValid = result.IsValid;
        _outlet.OutputMessages(result.Errors);
    }
}
