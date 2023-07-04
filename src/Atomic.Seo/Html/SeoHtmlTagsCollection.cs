using Umbraco.Cms.Core.Composing;

namespace Atomic.Seo.Html;

public class SeoHtmlTagsCollection : BuilderCollectionBase<ISeoHtmlTags>
{
    public SeoHtmlTagsCollection(Func<IEnumerable<ISeoHtmlTags>> items)
        : base(items)
    { }
}