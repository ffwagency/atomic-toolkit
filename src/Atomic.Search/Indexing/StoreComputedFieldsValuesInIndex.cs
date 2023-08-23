using Examine;
using Umbraco.Cms.Infrastructure.Examine;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Core.Composing;
using Microsoft.Extensions.Options;
using Atomic.Common.Content;
using Umbraco.Cms.Web.Common.PublishedModels;
using Umbraco.Extensions;
using Umbraco.Cms.Infrastructure.PublishedCache;
using Umbraco.Cms.Core;
using Atomic.Search.Fields;
using Atomic.Search.Fields.Base;

namespace Atomic.Search.Indexing;

public class StoreComputedFieldsValuesInIndex : IComponent
{
    private readonly IExamineManager _examineManager;
    private readonly IUmbracoContextFactory _umbracoContextFactory;
    private readonly AtomicSearchOptions _searchOptions;
    private readonly SearchFieldsCollection _searchFields;
    private readonly MultisiteContentService _multisiteContentService;

    public StoreComputedFieldsValuesInIndex(IExamineManager examineManager,
                                    IUmbracoContextFactory umbracoContextFactory,
                                    IOptions<AtomicSearchOptions> searchOptions,
                                    SearchFieldsCollection searchFields,
                                    MultisiteContentService multisiteContentService)
    {
        _examineManager = examineManager;
        _umbracoContextFactory = umbracoContextFactory;
        _searchOptions = searchOptions.Value;
        _searchFields = searchFields;
        _multisiteContentService = multisiteContentService;
    }

    public void Initialize()
    {
        if (!_searchOptions.Enabled)
            return;

        GetIndexProvider(Umbraco.Cms.Core.Constants.UmbracoIndexes.ExternalIndexName)
            .TransformingIndexValues += (sender, e) => ComputeFieldsValuesAndStoreThemInIndex(sender, e, inPreviewMode: false);
        GetIndexProvider(Umbraco.Cms.Core.Constants.UmbracoIndexes.InternalIndexName)
            .TransformingIndexValues += (sender, e) => ComputeFieldsValuesAndStoreThemInIndex(sender, e, inPreviewMode: true);
    }

    private BaseIndexProvider GetIndexProvider(string indexName)
    {
        if (!_examineManager.TryGetIndex(indexName, out IIndex index))
            throw new InvalidOperationException($"No index found by name {indexName}");
        if (index is not BaseIndexProvider indexProvider)
            throw new InvalidOperationException($"Cannot cast {indexName} to {nameof(BaseIndexProvider)}");

        return indexProvider;
    }

    private void ComputeFieldsValuesAndStoreThemInIndex(object? sender, IndexingItemEventArgs e, bool inPreviewMode)
    {
        var indexedContentNode = e.ValueSet;

        if (indexedContentNode.Category != IndexTypes.Content)
            return;

        var computedValueSet = new Dictionary<string, IEnumerable<object>>();
        foreach (var value in indexedContentNode.Values)
            computedValueSet.Add(value.Key, value.Value);

        using var context = _umbracoContextFactory.EnsureUmbracoContext();
        {
            if (inPreviewMode)
            {
                var forcedPreview = context.UmbracoContext.ForcedPreview(true);
                var publishedSnapshot = context.UmbracoContext.PublishedSnapshot as PublishedSnapshot;
                publishedSnapshot?.Resync(); // ForcedPreview(true) doesn't work by its own. this is needed as well (probably Umbraco Bug)

                AddComputedValues(indexedContentNode, computedValueSet, context);

                forcedPreview?.Dispose();
                publishedSnapshot?.Resync(); // ForcedPreview(true) doesn't work by its own. this is needed as well (probably Umbraco Bug)
                publishedSnapshot?.Dispose();
            }
            else
            {
                AddComputedValues(indexedContentNode, computedValueSet, context);
            }

        }

        e.SetValues(computedValueSet);
    }

    private void AddComputedValues(ValueSet indexedContentNode, Dictionary<string, IEnumerable<object>> computedValueSet, UmbracoContextReference context)
    {
        foreach (var computedField in _searchFields.GetSearchFields<SearchComputedField>())
        {
            var publishedContent = context.UmbracoContext.Content?.GetById(Convert.ToInt32(indexedContentNode.Id));
            var settings = _multisiteContentService.GetRequiredSettings<SearchSettings>(publishedContent?.Root());

            foreach (var value in computedField.GetFieldValue(publishedContent, settings))
                computedValueSet.Add(value.Key, value.Value);
        }
    }

    public void Terminate()
    { }
}