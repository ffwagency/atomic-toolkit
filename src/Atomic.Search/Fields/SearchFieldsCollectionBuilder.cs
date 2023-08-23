using Atomic.Search.Fields.Base;
using Umbraco.Cms.Core.Composing;

namespace Atomic.Search.Fields;

public class SearchFieldsCollectionBuilder : OrderedCollectionBuilderBase<SearchFieldsCollectionBuilder, SearchFieldsCollection, SearchField>
{
    protected override SearchFieldsCollectionBuilder This => this;
}