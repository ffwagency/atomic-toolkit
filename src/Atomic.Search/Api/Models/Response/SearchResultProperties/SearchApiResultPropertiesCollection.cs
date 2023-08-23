using Umbraco.Cms.Core.Composing;

namespace Atomic.Search.Api.Models.Response.SearchResultProperties;

public class SearchApiResultPropertiesCollection : BuilderCollectionBase<ISearchApiResultProperty>
{
    public SearchApiResultPropertiesCollection(Func<IEnumerable<ISearchApiResultProperty>> items)
        : base(items)
    { }
}