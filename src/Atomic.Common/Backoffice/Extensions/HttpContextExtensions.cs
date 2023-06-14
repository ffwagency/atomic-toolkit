using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Web;

namespace Atomic.Common.Backoffice.Extensions
{
	public static class HttpContextExtensions
	{
		public static bool InPreviewMode(this HttpContext httpContext)
		{
			if (httpContext.Request.Path.StartsWithSegments($"/{Constants.UmbracoPreviewKeyword}", StringComparison.OrdinalIgnoreCase))
				return true;

            if (httpContext.RequestServices.GetService<IUmbracoContextAccessor>()?.TryGetUmbracoContext(out var umbracoContext) == true
				&& umbracoContext.InPreviewMode)
				return true;

			return false;
		}
	}
}