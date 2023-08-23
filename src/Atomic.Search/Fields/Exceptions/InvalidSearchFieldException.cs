namespace Atomic.Search.Fields.Exceptions;

public class InvalidSearchFieldException : Exception
{
    public InvalidSearchFieldException()
    { }

    public InvalidSearchFieldException(string? message) : base(message)
    { }

    public InvalidSearchFieldException(string? message, Exception? innerException) : base(message, innerException)
    { }

    public static void ThrowIfNull<T>(T? searchField, string? searchFieldKey = null)
    {
        if (searchField == null)
        {
            var errorMessage = $"You must register Search Field of type: '{typeof(T)}'";
            if (!string.IsNullOrWhiteSpace(searchFieldKey))
                errorMessage += $" with Key: '{searchFieldKey}'";
            throw new InvalidSearchFieldException(errorMessage + ".");
        }
    }
}