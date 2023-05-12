using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Web.Common.ApplicationBuilder;
using Umbraco.Extensions;

namespace AtomicStarterKit.OutputCache;

public static class IUmbracoBuilderExtensions
{
    public static IUmbracoBuilder ConfigureOutputCache(this IUmbracoBuilder builder)
    {
        builder.Services.AddOutputCache(options =>
        {
            options.AddPolicy(Constants.DefaultPolicy, b =>
            {
                b.With(x => x.HttpContext.Request.Host.Value.InvariantContains("localhost")).NoCache();
                b.Expire(TimeSpan.FromMinutes(Constants.DefaultPolicyExpirationMinutes));
                b.Cache();
                b.Tag(Constants.DefaultPolicyTag);
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