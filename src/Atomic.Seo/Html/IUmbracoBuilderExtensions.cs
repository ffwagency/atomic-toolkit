using Umbraco.Cms.Core.DependencyInjection;

namespace Atomic.Seo.Html;

public static class IUmbracoBuilderExtensions
{
	public static SeoHtmlTagsCollectionBuilder SeoHtmlTags(this IUmbracoBuilder builder)
		=> builder.WithCollectionBuilder<SeoHtmlTagsCollectionBuilder>();
}