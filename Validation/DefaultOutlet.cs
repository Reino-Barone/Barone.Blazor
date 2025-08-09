using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Barone.Blazor.Validation;

/// <summary>
/// Represents the default implementation of a validation outlet.
/// </summary>
public class DefaultOutlet : IValidationOutlet, INotifyPropertyChanged
{
    bool _isValid = true;
    readonly List<string> _messages = [];
    void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// <inheritdoc cref="IValidationOutlet.Messages"/>
    /// </summary>
    public IEnumerable<string> Messages => _messages;

    /// <summary>
    /// Occurs when the property changes.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// <inheritdoc cref="IValidationOutlet.IsValid"/>
    /// </summary>
    public bool IsValid
    {
        get => _isValid;
        set
        {
            if (_isValid == value) return;
            _isValid = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// <inheritdoc cref="IValidationOutlet.OutputMessages(IEnumerable{string})"/>
    /// </summary>
    /// <param name="messages"></param>
    public void OutputMessages(IEnumerable<string> messages)
    {
        _messages.Clear();
        _messages.AddRange(messages);
        OnPropertyChanged(nameof(Messages));
    }
}
