using Atomic.Seo.Html;
using Atomic.Seo.Html.Tags;
using Atomic.Seo.SitemapXml;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.DependencyInjection;

namespace Atomic.Seo.DependencyInjection;

public static class IUmbracoBuilderExtensions
{
	internal static IUmbracoBuilder AddAtomicSeo(this IUmbracoBuilder builder)
	{
		builder.Services.AddSingleton<SeoHtmlTagsService>();
		builder.Services.AddSingleton<SitemapService>();

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