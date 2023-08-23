using Atomic.Search.Fields.Base;

namespace Atomic.Search.Fields.Exceptions;

public class InvalidSortableFieldException : Exception
{
    public InvalidSortableFieldException()
    { }

    public InvalidSortableFieldException(string? message) : base(message)
    { }

    public InvalidSortableFieldException(string? message, Exception? innerException) : base(message, innerException)
    { }

    public static void ThrowIfNotOfType<T>(SearchField searchField)
    {
        if (searchField is not T)
            throw new InvalidSearchFieldException($"Search field doesn't implement (inherit) '{typeof(T)}'.");
    }
}
