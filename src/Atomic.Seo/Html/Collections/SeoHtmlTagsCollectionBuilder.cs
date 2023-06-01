using Atomic.Sео.Html.Interfaces;
using Umbraco.Cms.Core.Composing;

namespace Atomic.Sео.Html.Collections;

public class SeoHtmlTagsCollectionBuilder : OrderedCollectionBuilderBase<SeoHtmlTagsCollectionBuilder, SeoHtmlTagsCollection, ISeoHtmlTags>
{
	protected override SeoHtmlTagsCollectionBuilder This => this;
}