using Atomic.Api.Preview;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Umbraco.Cms.Core.DependencyInjection;

namespace Atomic.Api.DependencyInjection;

public static class IUmbracoBuilderExtensions
{
	internal static IUmbracoBuilder AddAtomicApi(this IUmbracoBuilder builder)
	{
		builder.Services.AddScoped<ApiLinkGenerator>();

		builder.Services.TryAddEnumerable(ServiceDescriptor.Transient<IApplicationModelProvider, PreviewRouteApplicationModelProvider>());

		return builder;
	}
}