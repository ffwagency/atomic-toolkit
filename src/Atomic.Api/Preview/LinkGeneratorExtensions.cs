using Atomic.Api.Controllers;
using Atomic.Api.Preview;
using Atomic.Common.Backoffice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Linq.Expressions;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Extensions;

namespace Atomic.Api
{
    public static class LinkGeneratorExtensions
	{
        /// <summary>
        /// Get the appropriate Atomic Api Url. It will also take into consideration if the controller supports Preview and return the Preview Url if Umbraco is in Preview mode.
        /// </summary>
        /// <typeparam name="T">T UmbracoApiController</typeparam>
        /// <param name="linkGenerator">LinkGenerator</param>
        /// <param name="httpContext">HttpContext</param>
        /// <param name="actionSelector">Controller Action Selector</param>
        /// <returns>Umbraco Api Url</returns>
        public static string GetAtomicApiService<T>(this LinkGenerator linkGenerator, HttpContext httpContext, Expression<Func<T, object>> actionSelector) where T : UmbracoApiController, IAtomicApiController
		{
			ArgumentNullException.ThrowIfNull(httpContext);

            var defaultRoute = linkGenerator.GetUmbracoApiService(actionSelector);
            ArgumentException.ThrowIfNullOrEmpty(defaultRoute);

            if (UsePreviewRoute<T>(httpContext))
				return PreviewRouteConvention.BuildPreviewRoute(defaultRoute).ToLower();

			return defaultRoute.ToLower();
		}



        /// <summary>
        /// Get the Atomic Api Preview Url.
        /// </summary>
        /// <typeparam name="T">T UmbracoApiController, IAtomicUmbracoApiController</typeparam>
        /// <param name="linkGenerator">LinkGenerator</param>
        /// <param name="actionSelector">Controller Action Selector</param>
        /// <returns>Umbraco Api Preview Url</returns>
        public static string GetAtomicApiPreviewService<T>(this LinkGenerator linkGenerator, Expression<Func<T, object>> actionSelector) where T : UmbracoApiController, IAtomicApiController
		{
			NotSupportedPreviewException.ThrowIfDoesNotSupportPreview(typeof(T));

            var defaultRoute = linkGenerator.GetUmbracoApiService(actionSelector);
            ArgumentException.ThrowIfNullOrEmpty(defaultRoute);

            return PreviewRouteConvention.BuildPreviewRoute(defaultRoute).ToLower();
		}

		private static bool UsePreviewRoute<T>(HttpContext httpContext) where T : UmbracoApiController
		{
			return typeof(T).SupportsPreview() && httpContext.InPreviewMode();
		}
	}
}