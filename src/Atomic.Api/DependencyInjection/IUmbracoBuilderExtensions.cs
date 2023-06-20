using Atomic.Api.Preview;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.DependencyInjection;

namespace Atomic.Api.DependencyInjection;

public static class IUmbracoBuilderExtensions
{
	internal static IUmbracoBuilder AddAtomicApi(this IUmbracoBuilder builder)
	{
		builder.Services.AddScoped<ApiLinkGenerator>();

		builder.Services.TryAddEnumerable(ServiceDescriptor.Transient<IApplicationModelProvider, PreviewRouteApplicationModelProvider>());

		builder.Services.AddSingleton<IAuthorizationHandler, PreviewAuthHandler>();

		builder.Services.PostConfigure<AuthorizationOptions>(options =>
		{
			options.AddPolicy(PreviewAuthPolicy.Name, policy =>
			{
				policy.AuthenticationSchemes.Add(Constants.Security.BackOfficeAuthenticationType);
				policy.Requirements.Add(new PreviewAuthRequirement());
			});
		});

		return builder;
	}
}