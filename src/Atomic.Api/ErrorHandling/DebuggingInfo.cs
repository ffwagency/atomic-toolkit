namespace Atomic.Api.ErrorHandling;

public class DebuggingInfo
{
    public DebuggingInfo(string message)
    {
        Message = message;
        Errors = new List<Error>();
    }

    public string Message { get; }

    public List<Error> Errors { get; }
}

public record Error(string ExceptionMessage, string? StackTrace);