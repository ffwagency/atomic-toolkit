using Atomic.Api.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;

namespace Atomic.Api.Auth
{
	public class DisableLoginRedirectForAtomicApi : IPostConfigureOptions<CookieAuthenticationOptions>
	{
		public void PostConfigure(string? name, CookieAuthenticationOptions options)
		{
			var defaultOnRedirectToLogin = options.Events.OnRedirectToLogin;

			options.Events.OnRedirectToLogin = context =>
			{
				var endPoint = context.HttpContext.GetEndpoint();
				if (IsAtomicApiController(endPoint))
				{
					context.Response.StatusCode = StatusCodes.Status401Unauthorized;
					return Task.CompletedTask;
				}

				return defaultOnRedirectToLogin(context);
			};
		}

		private static bool IsAtomicApiController(Endpoint? endPoint)
		{
			return endPoint is RouteEndpoint routeEndpoint
				   && routeEndpoint.Metadata.GetMetadata<ControllerActionDescriptor>()?.ControllerTypeInfo?.ImplementedInterfaces.Contains(typeof(IAtomicApiController)) == true;
		}
	}
}