using Atomic.Sео.Html.Interfaces;
using Umbraco.Cms.Core.Composing;

namespace Atomic.Sео.Html.Collections;

public class SeoHtmlTagsCollection : BuilderCollectionBase<ISeoHtmlTags>
{
	public SeoHtmlTagsCollection(Func<IEnumerable<ISeoHtmlTags>> items)
		: base(items)
	{ }
}