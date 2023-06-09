﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Web;

namespace Atomic.Common.Backoffice;

public static class HttpContextExtensions
{
	public static bool InPreviewMode(this HttpContext? httpContext)
	{
		if (httpContext == null)
			return false;

		return httpContext.RequestServices.GetService<IUmbracoContextAccessor>()?.TryGetUmbracoContext(out var umbracoContext) == true
			   && umbracoContext.InPreviewMode;
	}
}