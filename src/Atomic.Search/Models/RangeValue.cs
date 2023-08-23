namespace Atomic.Search.Models;

public class RangeValue : ISearchValue
{
    private const char RangeStartSymbol = '[';
    private const char RangeEndSymbol = ']';
    private const char MinMaxDelimiter = ',';

    public RangeValue(double? min, double? max)
    {
        Min = min ?? double.MinValue;
        Max = max ?? double.MaxValue;
    }

    public RangeValue(long? min, long? max)
    {
        Min = min ?? long.MinValue;
        Max = max ?? long.MaxValue;
    }

    public object Min { get; internal set; }

    public object Max { get; internal set; }

    public bool IsEmpty
    {
        get
        {
            if (Type == typeof(long))
                return (long)Min == long.MinValue && (long)Max == long.MaxValue;

            if (Type == typeof(double))
                return (double)Min == double.MinValue && (double)Max == double.MaxValue;

            return true;
        }
    }

    public Type Type => Min.GetType();

    public static bool TryParse(string? input, out RangeValue? value)
    {
        value = null;

        if (string.IsNullOrWhiteSpace(input))
            return false;

        if (!IsValidRangeStringFormat(input))
            return false;

        var minMaxValues = input.Split(MinMaxDelimiter);

        if (ParseMinLong(minMaxValues, out var minLong) && ParseMaxLong(minMaxValues, out var maxLong))
        {
            value = new RangeValue(minLong, maxLong);
            return true;
        }

        if (ParseMinDouble(minMaxValues, out var minDouble) && ParseMaxDouble(minMaxValues, out var maxDouble))
        {
            value = new RangeValue(minDouble, maxDouble);
            return true;
        }

        return false;
    }

    private static bool ParseMaxLong(string[] minMaxValues, out long maxLong)
    {
        var raw = minMaxValues[1];
        if (string.IsNullOrWhiteSpace(raw))
        {
            maxLong = long.MaxValue;
            return true;
        }

        return long.TryParse(raw, out maxLong);
    }

    private static bool ParseMinLong(string[] minMaxValues, out long minLong)
    {
        var raw = minMaxValues[0];
        if (string.IsNullOrWhiteSpace(raw))
        {
            minLong = long.MinValue;
            return true;
        }

        return long.TryParse(raw, out minLong);
    }

    private static bool ParseMaxDouble(string[] minMaxValues, out double maxDouble)
    {
        var raw = minMaxValues[1];
        if (string.IsNullOrWhiteSpace(raw))
        {
            maxDouble = double.MaxValue;
            return true;
        }

        return double.TryParse(raw, out maxDouble);
    }

    private static bool ParseMinDouble(string[] minMaxValues, out double minDobule)
    {
        var raw = minMaxValues[0];
        if (string.IsNullOrWhiteSpace(raw))
        {
            minDobule = double.MinValue;
            return true;
        }

        return double.TryParse(raw, out minDobule);
    }

    private static bool IsValidRangeStringFormat(string input)
    {
        if (input.StartsWith(RangeStartSymbol) && input.EndsWith(RangeEndSymbol) && input.Contains(MinMaxDelimiter))
        {
            var minMaxValues = input.Split(MinMaxDelimiter);
            if (minMaxValues.Length == 2)
                return true;
        }

        return false;
    }
}