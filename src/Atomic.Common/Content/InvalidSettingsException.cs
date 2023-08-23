namespace Atomic.Search.Fields.Exceptions;

public class InvalidSettingsException : Exception
{
    public InvalidSettingsException()
    { }

    public InvalidSettingsException(string? message) : base(message)
    { }

    public InvalidSettingsException(string? message, Exception? innerException) : base(message, innerException)
    { }

    public static void ThrowIfNull<T>(T? settings)
    {
        if (settings == null)
            throw new InvalidSettingsException($"You must create settings for: '{typeof(T)}'.");
    }
}