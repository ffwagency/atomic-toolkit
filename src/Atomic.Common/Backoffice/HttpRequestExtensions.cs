using Microsoft.AspNetCore.Http;

namespace Atomic.Common.Backoffice;

public static class HttpRequestExtensions
{
	public static bool IsPreviewRequest(this HttpRequest? request)
	{
		if (request == null)
			return false;

		return request.Path.StartsWithSegments(Constants.PreviewRelativeUrlStartPath, StringComparison.OrdinalIgnoreCase);
	}
}