using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.DependencyInjection;

namespace Atomic.Api.Auth;

public static class IUmbracoBuilderExtensions
{
	internal static IUmbracoBuilder AddAtomicApiAuth(this IUmbracoBuilder builder)
	{
		builder.Services.AddSingleton<IAuthorizationHandler, AtomicAuthHandler>();

		builder.Services.PostConfigure<AuthorizationOptions>(options =>
		{
			options.AddPolicy(AtomicAuthPolicy.Name, policy =>
			{
				policy.AuthenticationSchemes.Add(Umbraco.Cms.Core.Constants.Security.BackOfficeAuthenticationType);
				policy.Requirements.Add(new AtomicAuthRequirement());
			});
		});

		builder.Services.ConfigureOptions<DisableLoginRedirectForAtomicApi>();

		return builder;
	}
}