using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.ApplicationBuilder;
using Umbraco.Extensions;

namespace Atomic.OutputCache;

public static class IUmbracoBuilderExtensions
{
	public static IUmbracoBuilder ConfigureOutputCache(this IUmbracoBuilder builder)
	{
		builder.Services.AddOutputCache(options =>
		{
			options.AddPolicy(Constants.DefaultPolicy, b =>
			{
				b.With(x =>
				{
					var isLocalHost = x.HttpContext.Request.Host.Value.InvariantContains("localhost");

					if (x.HttpContext.RequestServices.GetService<IUmbracoContextAccessor>()?.TryGetUmbracoContext(out var umbracoContext) == true)
						return !isLocalHost && !umbracoContext.InPreviewMode && !umbracoContext.IsDebug;
					else
						return !isLocalHost;
				}).Expire(TimeSpan.FromMinutes(Constants.DefaultPolicyExpirationMinutes))
				  .Cache()
				  .Tag(Constants.DefaultPolicyTag);
			});
		});

		builder.Services.Configure<UmbracoPipelineOptions>(options =>
		{
			options.AddFilter(new UmbracoPipelineFilter(
				Constants.UmbracoPipelineFilterName,
				applicationBuilder => { },
				applicationBuilder => applicationBuilder.UseOutputCache(),
				applicationBuilder => { }
			));
		});

		builder.AddNotificationAsyncHandler<ContentPublishedNotification, ClearOutputCacheOnContentPublishedHandler>();

		return builder;
	}
}