using Atomic.Common.Api.Preview;
using Atomic.Common.Backoffice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Linq.Expressions;
using Umbraco.Cms.Core;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Extensions;

namespace Atomic.Common.Api
{
    public class ApiLinkGenerator
    {
        private readonly LinkGenerator _linkGenerator;

        public ApiLinkGenerator(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }

        /// <summary>
        /// Get the appropriate Umbraco Api Url taking into consideration Umbraco is in Preview mode or not.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// /// <param name="httpContext"></param>
        /// <param name="actionSelector">Controller Action Selector</param>
        /// <returns>Umbraco Api Url</returns>
        public string GetUmbracoApiUrl<T>(HttpContext httpContext, Expression<Func<T, object>> actionSelector) where T : UmbracoApiController
        {
            ArgumentNullException.ThrowIfNull(httpContext);

            var defaultRoute = GetUmbracoApiDefaultUrl(actionSelector);

            if (UsePreviewRoute<T>(httpContext))
                return PreviewRouteConvention.BuildPreviewRoute(defaultRoute);

            return defaultRoute;
        }

        /// <summary>
        /// Implicitly get the Umbraco Api Default Url. Works when HtptContext is not available.
        /// </summary>
        /// <typeparam name="T">T UmbracoApiController</typeparam>
        /// <param name="actionSelector">Controller Action Selector</param>
        /// <returns>Default Umbraco Api Url</returns>
        public string GetUmbracoApiDefaultUrl<T>(Expression<Func<T, object>> actionSelector) where T : UmbracoApiController
        {
            var method = ExpressionHelper.GetMethodInfo(actionSelector);
            ArgumentNullException.ThrowIfNull(method);

            var methodParams = ExpressionHelper.GetMethodParams(actionSelector);

            var defaultRoute = methodParams?.Any() == false
                                ? _linkGenerator.GetUmbracoApiService<T>(method.Name)
                                : _linkGenerator.GetUmbracoApiService<T>(method.Name, methodParams);
            ArgumentException.ThrowIfNullOrEmpty(defaultRoute);

            return defaultRoute;
        }

        /// <summary>
        /// Implicitly get the Umbraco Api Preview Url. Works when HttpContext is not available.
        /// </summary>
        /// <typeparam name="T">T UmbracoApiController</typeparam>
        /// <param name="actionSelector">Controller Action Selector</param>
        /// <returns>Umbraco Api Preview Url</returns>
        public string GetUmbracoApiPreviewUrl<T>(Expression<Func<T, object>> actionSelector) where T : UmbracoApiController
        {
            NotSupportedPreviewRouteException.ThrowIfHasNoPreviewRouteAttribute<T>();

            var defaultRoute = GetUmbracoApiDefaultUrl(actionSelector);

            return PreviewRouteConvention.BuildPreviewRoute(defaultRoute);
        }

        private static bool UsePreviewRoute<T>(HttpContext httpContext) where T : UmbracoApiController
        {
            return typeof(T).HasPreviewRouteAttribute() && httpContext.InPreviewMode();
        }
    }
}