namespace Barone.Blazor.Validation;

public class ValidationContext : IValidatable
{
    byte _validatablesCount = 0;
    readonly Dictionary<IValidatable, byte> _validatables = [];
    public bool IsValid => _validatables.Keys.All(v => v.IsValid);
    public IEnumerable<string> ValidationErrors => _validatables.Keys.SelectMany(v => v.ValidationErrors);
    public int Count => _validatablesCount;    
    public void AddValidatable(IValidatable validatable)
    {
        _validatables.Add(validatable, _validatablesCount++);
    }
}
