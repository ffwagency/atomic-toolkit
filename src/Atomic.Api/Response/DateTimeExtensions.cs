namespace Atomic.Api.Response;

public static class DateTimeExtensions
{
    public static string? ToISO8601(this DateTime dateTime)
    {
        const string ISO8601Format = "o";

        if (dateTime == DateTime.MinValue)
            return null;

        return dateTime.ToUniversalTime().ToString(ISO8601Format);
    }
}
