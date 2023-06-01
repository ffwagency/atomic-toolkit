using Atomic.Sео.Html.Collections;
using Atomic.Sео.Html.Tags;
using Umbraco.Cms.Core.DependencyInjection;

namespace Atomic.Sео.DependencyInjection;

public static class IUmbracoBuilderExtensions
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