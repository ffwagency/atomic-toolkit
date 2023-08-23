using Atomic.Search.Fields;
using Atomic.Search.Fields.Base;
using Examine;
using Examine.Lucene;
using Microsoft.Extensions.Options;
using Umbraco.Extensions;

namespace Atomic.Search.Indexing;

public class RegisterComputedFieldsDefinitonsInIndex : IConfigureNamedOptions<LuceneDirectoryIndexOptions>
{
    private readonly SearchFieldsCollection _searchFields;

    public RegisterComputedFieldsDefinitonsInIndex(SearchFieldsCollection searchFields)
    {
        _searchFields = searchFields;
    }

    public void Configure(string? name, LuceneDirectoryIndexOptions options)
    {
        if (!IsExternalOrInternalIndex(name))
            return;

        foreach (var computedField in _searchFields.GetSearchFields<SearchComputedField>())
            options.FieldDefinitions.AddOrUpdate(new FieldDefinition(computedField.ExamineNameWithoutCulture, computedField.Type));
    }

    public void Configure(LuceneDirectoryIndexOptions options) => Configure(string.Empty, options);

    private static bool IsExternalOrInternalIndex(string? indexName)
    {
        return Umbraco.Cms.Core.Constants.UmbracoIndexes.ExternalIndexName.InvariantEquals(indexName)
               || Umbraco.Cms.Core.Constants.UmbracoIndexes.InternalIndexName.InvariantEquals(indexName);
    }
}