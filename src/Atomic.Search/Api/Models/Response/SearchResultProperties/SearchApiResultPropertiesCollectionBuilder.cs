using Umbraco.Cms.Core.Composing;

namespace Atomic.Search.Api.Models.Response.SearchResultProperties;

public class SearchApiResultPropertiesCollectionBuilder : OrderedCollectionBuilderBase<SearchApiResultPropertiesCollectionBuilder, SearchApiResultPropertiesCollection, ISearchApiResultProperty>
{
    protected override SearchApiResultPropertiesCollectionBuilder This => this;
}