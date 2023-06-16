using Umbraco.Cms.Web.Common.Controllers;

namespace Atomic.Api.Preview;

public class NotSupportedPreviewException : Exception
{
	public NotSupportedPreviewException()
	{ }

	public NotSupportedPreviewException(string? message) : base(message)
	{ }

	public NotSupportedPreviewException(string? message, Exception? innerException) : base(message, innerException)
	{ }

	public static void ThrowIfDoesNotSupportPreview(Type? type)
	{
		if (type?.SupportsPreview() != true)
			throw new NotSupportedPreviewException($"'{type?.FullName ?? "NULL"}' type must be decorated with '{nameof(EnablePreviewAttribute)}', inherit from '{nameof(UmbracoApiController)}' and implement '{nameof(IAtomicUmbracoApiController)}' in order the Preview Route to be available.");
	}
}