using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Barone.Blazor.Validation;

public class DefaultOutlet : IValidationOutlet, INotifyPropertyChanged
{
    bool _isValid = true;
    readonly List<string> _messages = new();
    public IEnumerable<string> Messages => _messages;

    public event PropertyChangedEventHandler? PropertyChanged;

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

    public void OutputMessages(IEnumerable<string> messages)
    {
        _messages.Clear();
        _messages.AddRange(messages);
        OnPropertyChanged(nameof(Messages));
    }

    void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
