using Atomic.Sео.Html.Collections;
using Atomic.Sео.Html.Services;
using Atomic.Sео.Html.Tags;
using Atomic.Sео.SitemapXml.Services;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.DependencyInjection;

namespace Atomic.Sео.DependencyInjection;

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