using AtomicStarterKit.Sео.Html.Collections;
using AtomicStarterKit.Sео.Html.Tags;
using Umbraco.Cms.Core.DependencyInjection;

namespace AtomicStarterKit.Sео.DependencyInjection.Extensions;

public static class UmbracoBuilderExtensions
{
    internal static IUmbracoBuilder AddDefaultSeoHtmlTags(this IUmbracoBuilder builder)
    {
        builder.SeoHtmlTags()
            .Append<Title>()
            .Append<Description>()
            .Append<Keywords>()
            .Append<Robots>()
            .Append<CanonicalUrl>()
            .Append<AlternateUrls>()
            .Append<FacebookOpenGraph>()
            .Append<TwitterCards>();

        return builder;
    }

    public static SeoHtmlTagsCollectionBuilder SeoHtmlTags(this IUmbracoBuilder builder)
        => builder.WithCollectionBuilder<SeoHtmlTagsCollectionBuilder>();
}