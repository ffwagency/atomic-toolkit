using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Umbraco.Cms.Core.DependencyInjection;

namespace Atomic.Api.Preview;

public static class IUmbracoBuilderExtensions
{
	internal static IUmbracoBuilder AddAtomicApiPreview(this IUmbracoBuilder builder)
	{
		builder.Services.TryAddEnumerable(ServiceDescriptor.Transient<IApplicationModelProvider, PreviewRouteApplicationModelProvider>());
		return builder;
	}
}