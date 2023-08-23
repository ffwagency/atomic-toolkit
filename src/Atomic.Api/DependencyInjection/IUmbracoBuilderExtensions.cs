using Atomic.Api.Auth;
using Atomic.Api.Preview;
using Atomic.Common.Configuration;
using Umbraco.Cms.Core.DependencyInjection;

namespace Atomic.Api.DependencyInjection;

public static class IUmbracoBuilderExtensions
{
	internal static IUmbracoBuilder AddAtomicApi(this IUmbracoBuilder builder)
	{
		builder.AddAtomicOptions<AtomicApiOptions>();

		builder.AddAtomicApiPreview();

		builder.AddAtomicApiAuth();

		return builder;
	}
}