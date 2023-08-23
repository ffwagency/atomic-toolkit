using Umbraco.Extensions;

namespace Atomic.Search.Models;

public class MultiValue : ISearchValue
{
    private const string NegationSymbol = "^";
    public const char MultipleValuesSeparator = ',';

    public MultiValue(IEnumerable<SingleValue> values, bool negation = false)
    {
        var notEmptyValues = values?.Where(x => x?.IsEmpty == false).ToArray();
        if (notEmptyValues?.Length > 0)
            Values = notEmptyValues!;
        else
            Values = Array.Empty<SingleValue>();

        if (Values.FirstOrDefault()?.RawValue.StartsWith(NegationSymbol) == true)
            IsNegation = true;
        else
            IsNegation = negation;
    }

    public SingleValue[] Values { get; }

    public bool IsEmpty => Values.Length == 0;

    public bool IsNegation { get; }

    public static bool TryParse(string? input, out MultiValue? value)
    {
        value = null;

        if (string.IsNullOrWhiteSpace(input))
            return false;

        if (!input.Contains(MultipleValuesSeparator))
            return false;

        var values = input.Split(MultipleValuesSeparator, StringSplitOptions.RemoveEmptyEntries)
                          .Select(x => new SingleValue(x));
        value = new MultiValue(values);

        return true;
    }

    public static bool TryParse(IEnumerable<string?>? input, out MultiValue? value, bool negation = false)
    {
        value = null;

        if (input == null)
            return false;

        var values = input.Select(x => new SingleValue(x));
        value = new MultiValue(values, negation);

        return true;
    }
}