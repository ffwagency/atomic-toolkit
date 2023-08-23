using Microsoft.Extensions.Logging;

namespace Atomic.Common.ErrorHandling;

public static class ILoggerExtensions
{
    public static string LogErrorWithUniqueID(this ILogger logger, Exception exception)
    {
        var uniqueID = Guid.NewGuid().ToString("N");
        logger.LogError(exception, $"{ErrorMessages.InternalServerError} ErrorUniqueID - {{UniqueID}}. ErrorMessage - {{Message}}", uniqueID, exception.MessageWithImportantInfo());
        return uniqueID;
    }
}