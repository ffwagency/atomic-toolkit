namespace Atomic.Search.Models;

public class Boost
{
    public const float Min = 0.0000000001f;

    public Boost(float? value = null)
    {
        Value = value ?? Min;
    }

    public Boost(double? value = null)
    {
        value ??= Min;
        Value = (float)value;
    }

    public Boost(decimal? value = null)
    {
        var floatValue = Min;

        if (value != null)
            floatValue = (float)value;

        Value = floatValue;
    }

    public float Value { get; }
}