using Umbraco.Cms.Web.Common.Controllers;

namespace Atomic.Common.Api.Preview;

public class NotSupportedPreviewRouteException : Exception
{
    public NotSupportedPreviewRouteException()
    { }

    public NotSupportedPreviewRouteException(string? message) : base(message)
    { }

    public NotSupportedPreviewRouteException(string? message, Exception? innerException) : base(message, innerException)
    { }

    public static void ThrowIfHasNoPreviewRouteAttribute<T>() where T : UmbracoApiController
    {
        if (!typeof(T).HasPreviewRouteAttribute())
            throw new NotSupportedPreviewRouteException($"'{typeof(T).FullName}' must be decorated with '{nameof(EnablePreviewRouteAttribute)}' in order Preview Route to be available.");
    }
}