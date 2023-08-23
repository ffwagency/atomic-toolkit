using Atomic.Search.Querying;

namespace Atomic.Search.Models;

public class SingleValue : ISearchValue
{
    private const string NegationSymbol = "^";

    public SingleValue(string? value, float? boost = null, bool negation = false)
    {
        RawValue = value ?? string.Empty;
        Boost = new Boost(boost);
        if (RawValue.StartsWith(NegationSymbol))
            IsNegation = true;
        else
            IsNegation = negation;
    }

    public string RawValue { get; }

    private string? _value;
    public string Value => _value ??= RawValue.Sanitize();

    public Boost Boost { get; }

    public bool IsNegation { get; }

    public bool IsEmpty => string.IsNullOrWhiteSpace(RawValue);

    public bool IsSingleWord => !Value.Contains(' ');

    public string[] SplitWords => Value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

    public static SingleValue Empty => new(string.Empty);

    public static SingleValue Parse(string? input, float? boost = null)
    {
        return new SingleValue(input, boost);
    }
}