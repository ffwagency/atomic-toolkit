using Umbraco.Cms.Core.Composing;

namespace Atomic.Seo.Html;

public class SeoHtmlTagsCollectionBuilder : OrderedCollectionBuilderBase<SeoHtmlTagsCollectionBuilder, SeoHtmlTagsCollection, ISeoHtmlTags>
{
    protected override SeoHtmlTagsCollectionBuilder This => this;
}