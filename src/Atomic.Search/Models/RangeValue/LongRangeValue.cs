namespace Atomic.Search.Models.RangeValue;

public class LongRangeValue : RangeValue<long>
{
    public LongRangeValue(long? min, long? max)
    {
        Min = min ?? long.MinValue;
        Max = max ?? long.MaxValue;
    }

    public override long Min { get; internal set; }

    public override long Max { get; internal set; }

    public override bool IsEmpty => Min == long.MinValue && Max == long.MaxValue;

    public static bool TryParse(string? input, out LongRangeValue? value)
    {
        value = null;

        if (string.IsNullOrWhiteSpace(input))
            return false;

        if (!RangeValueHelper.IsValidRangeStringFormat(input))
            return false;

        var minMaxValues = input.Split(RangeValueHelper.MinMaxDelimiter);

        if (ParseMinLong(minMaxValues, out var minLong) && ParseMaxLong(minMaxValues, out var maxLong))
        {
            value = new LongRangeValue(minLong, maxLong);
            return true;
        }

        return false;
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
}