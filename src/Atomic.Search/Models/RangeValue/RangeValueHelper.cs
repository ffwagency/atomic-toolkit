namespace Atomic.Search.Models.RangeValue;

public static class RangeValueHelper
{
    public const char RangeStartSymbol = '[';
    public const char RangeEndSymbol = ']';
    public const char MinMaxDelimiter = ',';

    public static bool IsValidRangeStringFormat(string input)
    {
        if (input.StartsWith(RangeStartSymbol) && input.EndsWith(RangeEndSymbol) && input.Contains(MinMaxDelimiter))
        {
            var minMaxValues = input.Split(MinMaxDelimiter);
            if (minMaxValues.Length == 2)
                return true;
        }

        return false;
    }

    public static bool TryParse(string? input, out IRangeValue? value)
    {
        value = null;

        if (LongRangeValue.TryParse(input, out var longRangeValue))
        {
            value = longRangeValue;
            return true;
        }

        if (DoubleRangeValue.TryParse(input, out var doubleRangeValue))
        {
            value = doubleRangeValue;
            return true;
        }

        return false;
    }
}