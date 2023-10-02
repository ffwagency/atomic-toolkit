namespace Atomic.Search.Models.RangeValue;

public class DoubleRangeValue : RangeValue<double>
{
    public DoubleRangeValue(double? min, double? max)
    {
        Min = min ?? double.MinValue;
        Max = max ?? double.MaxValue;
    }

    public override double Min { get; internal set; }

    public override double Max { get; internal set; }

    public override bool IsEmpty => Min == double.MinValue && Max == double.MaxValue;

    public static bool TryParse(string? input, out DoubleRangeValue? value)
    {
        value = null;

        if (string.IsNullOrWhiteSpace(input))
            return false;

        if (!RangeValueHelper.IsValidRangeStringFormat(input))
            return false;

        var minMaxValues = input.Split(RangeValueHelper.MinMaxDelimiter);

        if (ParseMinDouble(minMaxValues, out var minDouble) && ParseMaxDouble(minMaxValues, out var maxDouble))
        {
            value = new DoubleRangeValue(minDouble, maxDouble);
            return true;
        }

        return false;
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
}