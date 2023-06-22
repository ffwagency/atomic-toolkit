using Atomic.Api.Controllers;
using Atomic.Api.Preview;
using Atomic.Common.Backoffice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Linq.Expressions;
using Umbraco.Cms.Core;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Extensions;

namespace Atomic.Api
{
    public class ApiLinkGenerator
	{
		private readonly LinkGenerator _linkGenerator;

		public ApiLinkGenerator(LinkGenerator linkGenerator)
		{
			_linkGenerator = linkGenerator;
		}

		/// <summary>
		/// Get the appropriate Umbraco Api Url. It will also take into consideration if the controller supports Preview and return the Preview Url if Umbraco is in Preview mode.
		/// </summary>
		/// <typeparam name="T">T UmbracoApiController</typeparam>
		/// /// <param name="httpContext"></param>
		/// <param name="actionSelector">Controller Action Selector</param>
		/// <returns>Umbraco Api Url</returns>
		public string GetAtomicApiUrl<T>(HttpContext httpContext, Expression<Func<T, object>> actionSelector) where T : UmbracoApiController, IAtomicApiController
		{
			ArgumentNullException.ThrowIfNull(httpContext);

			var defaultRoute = GetUmbracoApiUrl(actionSelector);

			if (UsePreviewRoute<T>(httpContext))
				return PreviewRouteConvention.BuildPreviewRoute(defaultRoute).ToLower();

			return defaultRoute;
		}

		/// <summary>
		/// Implicitly get the Umbraco Api Default Url.
		/// </summary>
		/// <typeparam name="T">T UmbracoApiController</typeparam>
		/// <param name="actionSelector">Controller Action Selector</param>
		/// <returns>Default Umbraco Api Url</returns>
		public string GetUmbracoApiUrl<T>(Expression<Func<T, object>> actionSelector) where T : UmbracoApiController
		{
			var method = ExpressionHelper.GetMethodInfo(actionSelector);
			ArgumentNullException.ThrowIfNull(method);

			var methodParams = ExpressionHelper.GetMethodParams(actionSelector);

			var defaultRoute = methodParams?.Any() == false
								? _linkGenerator.GetUmbracoApiService<T>(method.Name)
								: _linkGenerator.GetUmbracoApiService<T>(method.Name, methodParams);
			ArgumentException.ThrowIfNullOrEmpty(defaultRoute);

			return defaultRoute.ToLower();
		}

		/// <summary>
		/// Implicitly get the Umbraco Api Preview Url.
		/// </summary>
		/// <typeparam name="T">T UmbracoApiController, IAtomicUmbracoApiController</typeparam>
		/// <param name="actionSelector">Controller Action Selector</param>
		/// <returns>Umbraco Api Preview Url</returns>
		public string GetAtomicApiPreviewUrl<T>(Expression<Func<T, object>> actionSelector) where T : UmbracoApiController, IAtomicApiController
		{
			NotSupportedPreviewException.ThrowIfDoesNotSupportPreview(typeof(T));

			var defaultRoute = GetUmbracoApiUrl(actionSelector);

			return PreviewRouteConvention.BuildPreviewRoute(defaultRoute).ToLower();
		}

		private static bool UsePreviewRoute<T>(HttpContext httpContext) where T : UmbracoApiController
		{
			return typeof(T).SupportsPreview() && httpContext.InPreviewMode();
		}
	}
}