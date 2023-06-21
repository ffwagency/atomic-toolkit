using Atomic.Api.Auth;
using Atomic.Api.Preview;
using Atomic.Common.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.DependencyInjection;

namespace Atomic.Api.DependencyInjection;

public static class IUmbracoBuilderExtensions
{
	internal static IUmbracoBuilder AddAtomicApi(this IUmbracoBuilder builder)
	{
		builder.AddAtomicOptions<AtomicApiOptions>();

		builder.Services.AddScoped<ApiLinkGenerator>();

		builder.AddAtomicApiPreview();

		builder.AddAtomicApiAuth();

		return builder;
	}
}