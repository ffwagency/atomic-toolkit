using AtomicStarterKit.Sео.Html.Interfaces;
using Umbraco.Cms.Core.Composing;

namespace AtomicStarterKit.Sео.Html.Collections;

public class SeoHtmlTagsCollection : BuilderCollectionBase<ISeoHtmlTags>
{
    public SeoHtmlTagsCollection(Func<IEnumerable<ISeoHtmlTags>> items)
        : base(items)
    { }
}