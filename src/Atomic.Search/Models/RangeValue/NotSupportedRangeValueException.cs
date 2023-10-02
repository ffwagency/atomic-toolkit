namespace Atomic.Search.Models.RangeValue;

public class NotSupportedRangeValueException : Exception
{
    public NotSupportedRangeValueException()
    { }

    public NotSupportedRangeValueException(string? message) : base(message)
    { }

    public NotSupportedRangeValueException(string? message, Exception? innerException) : base(message, innerException)
    { }
}