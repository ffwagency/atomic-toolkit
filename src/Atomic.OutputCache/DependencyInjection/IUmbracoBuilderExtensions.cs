using Atomic.Common.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Web.Common.ApplicationBuilder;
using Umbraco.Cms.Web.Website.Controllers;

namespace Atomic.OutputCache.DependencyInjection;

public static class IUmbracoBuilderExtensions
{
	internal static IUmbracoBuilder AddAtomicOutputCache(this IUmbracoBuilder builder)
	{
		builder.AddAtomicOptions<AtomicOutputCacheOptions>();

		builder.Services.AddOutputCache(options
			=> options.AddPolicy(Constants.AtomicPolicyName, builder => builder.AddPolicy<AtomicOutputCachePolicy>(),
			                         excludeDefaultPolicy: true));

		builder.Services.Configure<UmbracoPipelineOptions>(options =>
		{
			options.AddFilter(new UmbracoPipelineFilter(nameof(AtomicOutputCacheComposer))
			{
				PostPipeline = applicationBuilder =>
				{
					var outputCacheOptions = applicationBuilder.ApplicationServices.GetRequiredService<IOptions<AtomicOutputCacheOptions>>().Value;

					if (!outputCacheOptions.Enabled)
						return;

					applicationBuilder.UseOutputCache();
				}
			});
		});

		builder.Services.Configure<UmbracoRenderingDefaultsOptions>(c =>
		{
			c.DefaultControllerType = typeof(CachedAtomicController);
		});

		builder.AddNotificationAsyncHandler<ContentPublishedNotification, ClearOutputCacheOnContentPublishedHandler>();

		return builder;
	}
}