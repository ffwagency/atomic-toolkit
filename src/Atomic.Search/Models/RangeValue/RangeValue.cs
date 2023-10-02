namespace Atomic.Search.Models.RangeValue;

public abstract class RangeValue<T> : IRangeValue
{
    public abstract T Min { get; internal set; }

    public abstract T Max { get; internal set; }

    public abstract bool IsEmpty { get; }
}