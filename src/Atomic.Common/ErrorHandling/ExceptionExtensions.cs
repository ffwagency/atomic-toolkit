namespace Atomic.Common.ErrorHandling;

public static class ExceptionExtensions
{
    private const string ImportantInfoKey = "ImportantInfo";

    public static void AddImportantInfo(this Exception exception, string message)
    {
        exception.Data[ImportantInfoKey] = message;
    }

    public static string? GetImportantInfo(this Exception exception)
    {
        return exception.Data[ImportantInfoKey] as string;
    }

    public static string MessageWithImportantInfo(this Exception exception)
    {
        return $"{exception.GetImportantInfo()} {exception.Message}".Trim();
    }
}