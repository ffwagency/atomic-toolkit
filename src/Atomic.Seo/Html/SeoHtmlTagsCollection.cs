using Umbraco.Cms.Core.Composing;

namespace Atomic.Sео.Html;

public class SeoHtmlTagsCollection : BuilderCollectionBase<ISeoHtmlTags>
{
    public SeoHtmlTagsCollection(Func<IEnumerable<ISeoHtmlTags>> items)
        : base(items)
    { }
}