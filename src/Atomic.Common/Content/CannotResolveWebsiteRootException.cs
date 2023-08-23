using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.Common.Content;

public class CannotResolveWebsiteRootException : Exception
{
    public CannotResolveWebsiteRootException()
    { }

    public CannotResolveWebsiteRootException(string? message) : base(message)
    { }

    public CannotResolveWebsiteRootException(string? message, Exception? innerException) : base(message, innerException)
    { }

    public static void ThrowIfHostnameIsNotConfigured(IDomain? domain, string websiteHostname)
    {
        if (domain?.RootContentId == null)
            throw new CannotResolveWebsiteRootException($"You must configure Umbraco domain definition for {websiteHostname}.");
    }

    public static void ThrowIfCannotResolveRequestHostname(string? hostname)
    {
        if (string.IsNullOrWhiteSpace(hostname))
            throw new CannotResolveWebsiteRootException("There is an issue resolving the hostname from HttpRequest.");
    }

    public static void ThrowIfWebsiteRootIsNotOfType<T>(
        IPublishedContent? websiteRoot)
    {
        if (websiteRoot is not T)
            throw new CannotResolveWebsiteRootException($"Website root is not of type '{typeof(T)}'");
    }
}