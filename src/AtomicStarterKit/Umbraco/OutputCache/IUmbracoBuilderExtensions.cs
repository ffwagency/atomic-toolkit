using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Web.Common.ApplicationBuilder;
using Umbraco.Extensions;

namespace AtomicStarterKit.Umbraco.OutputCache;

public static class IUmbracoBuilderExtensions
{
	public static IUmbracoBuilder ConfigureOutputCache(this IUmbracoBuilder builder)
	{
		builder.Services.AddOutputCache(options =>
		{
			options.AddPolicy(CachingConstants.DefaultPolicy, b =>
			{
				b.With(x => x.HttpContext.Request.Host.Value.InvariantContains("localhost")).NoCache();
				b.Expire(TimeSpan.FromMinutes(CachingConstants.DefaultPolicyExpirationMinutes));
				b.Cache();
				b.Tag(CachingConstants.DefaultPolicyTag);
			});
		});

		builder.Services.Configure<UmbracoPipelineOptions>(options =>
		{
			options.AddFilter(new UmbracoPipelineFilter(
				CachingConstants.UmbracoPipelineFilterName,
				applicationBuilder => { },
				applicationBuilder => applicationBuilder.UseOutputCache(),
				applicationBuilder => { }
			));
		});

		builder.AddNotificationAsyncHandler<ContentPublishedNotification, ContentPublishedClearOutputCacheHandler>();

		return builder;
	}
}