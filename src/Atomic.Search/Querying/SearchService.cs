using Examine;
using Examine.Search;
using Umbraco.Cms.Infrastructure.Examine;
using Umbraco.Extensions;
using Microsoft.Extensions.Logging;
using Atomic.Common.Content;
using Umbraco.Cms.Core.Models.PublishedContent;
using Atomic.Search.Fields;
using Atomic.Common.Pagination;
using Umbraco.Cms.Web.Common.PublishedModels;
using Atomic.Search.Models;
using Atomic.Search.Fields.Base;
using Atomic.Search.Models.RangeValue;

namespace Atomic.Search.Querying;

public class SearchService
{
    private readonly IExamineManager _examineManager;
    private readonly ILogger<SearchService> _logger;
    private readonly MultisiteContentService _multisiteContentService;
    private readonly SearchFieldsCollection _searchFields;
    private static IEnumerable<SingleValue> PageBoostValues => new List<SingleValue>()
    {
        new SingleValue("10", 10),
        new SingleValue("20", 20),
        new SingleValue("30", 30),
        new SingleValue("40", 40),
        new SingleValue("50", 50),
        new SingleValue("60", 60),
        new SingleValue("70", 70),
        new SingleValue("80", 80),
        new SingleValue("90", 90),
        new SingleValue("100", 100)
    };

    public SearchService(IExamineManager examineManager,
                         ILogger<SearchService> logger,
                         MultisiteContentService multisiteContentService,
                         SearchFieldsCollection searchFields)
    {
        _examineManager = examineManager;
        _logger = logger;
        _multisiteContentService = multisiteContentService;
        _searchFields = searchFields;
    }

    public PagedResult<ISearchResult> Search(SearchQuery searchQuery, bool inPreviewMode = false)
    {

        ArgumentNullException.ThrowIfNull(searchQuery);

        //TODO: Refactor to SearchPipeline

        #region Initialize
        var searcher = GetSearcher(inPreviewMode);
        var criteria = searcher.CreateQuery(IndexTypes.Content);
        var settings = _multisiteContentService.GetRequiredSettings<SearchSettings>();
        #endregion

        #region RemoveResultsFromOtherSites
        var booleanOperation = RemoveResultsFromOtherSites(criteria);
        #endregion

        // every method bellow goes to step as well 
        RemoveExcludedDocumentTypes(booleanOperation, settings);
        //Step
        RemoveExcludedPages(booleanOperation);
        //Step
        RemoveNotSearchablePages(booleanOperation);
        //Step
        ApplyPageBoosting(booleanOperation);

        // Step
        if (searchQuery.TextQuery?.IsEmpty == false)
            AddTextQuery(booleanOperation, searchQuery.TextQuery, settings);

        // Step
        if (searchQuery.FilterQuery?.IsEmpty == false)
            AddFilterQuery(booleanOperation, searchQuery.FilterQuery);
        
        // Step
        if (searchQuery.SortQuery?.IsEmpty == false)
            AddSortQuery(booleanOperation, searchQuery.SortQuery);

        #region Execute search
        var pagination = new QueryOptions((searchQuery.PageNumber - 1) * searchQuery.PageSize, searchQuery.PageSize);

        _logger.LogInformation("'{RawLuceneQuery}' is being executed.", booleanOperation.ToString());

        var results = booleanOperation.Execute(pagination);
        #endregion

        // This is also a step
        return BuildPagedSearchResult(searchQuery, results);
    }

    private static PagedResult<ISearchResult> BuildPagedSearchResult(SearchQuery searchQuery, ISearchResults results)
    {
        return results switch
        {
            null => PagedResult<ISearchResult>.Empty(searchQuery.PageNumber, searchQuery.PageSize),
            _ => new PagedResult<ISearchResult>(searchQuery.PageNumber, searchQuery.PageSize, results, results.TotalItemCount),
        };
    }

    private IBooleanOperation RemoveResultsFromOtherSites(IQuery criteria)
    {
        return criteria.SingleValueQuery(_searchFields.GetRequiredSearchField<PathField>(),
            _multisiteContentService.GetWebsiteRoot<IPublishedContent>().Id.ToString().ToSearchSingleValue());
    }

    private void RemoveExcludedDocumentTypes(IBooleanOperation booleanOperation, SearchSettings settings)
    {
        if (!MultiValue.TryParse(settings.ExcludedDocumentTypesAliases, out var multiValue, true))
            return;

        if (multiValue!.IsEmpty)
            return;

        var searchField = _searchFields.GetRequiredSearchField<DocumentTypeAliasSearchField>();
        booleanOperation = booleanOperation.And().MultiValueQuery(searchField, multiValue);
    }

    private void RemoveExcludedPages(IBooleanOperation booleanOperation)
    {
        booleanOperation = booleanOperation.And().SingleValueQuery(
            _searchFields.GetRequiredSearchField<ExcludeFromSearchField>(),
            "1".ToSearchSingleValue(negate: true));
    }

    private void ApplyPageBoosting(IBooleanOperation booleanOperation)
    {
        booleanOperation = booleanOperation.Or().MultiValueQuery(_searchFields.GetRequiredSearchField<BoostField>(),
            new MultiValue(PageBoostValues));
    }

    private void RemoveNotSearchablePages(IBooleanOperation booleanOperation)
    {
        booleanOperation = booleanOperation.And().SingleValueQuery(
            _searchFields.GetRequiredSearchField<InheritsSearchBasePage>(),
            InheritsSearchBasePage.Yes.ToSearchSingleValue());
    }

    private void AddTextQuery(IBooleanOperation booleanOperation, TextQuery textQuery, SearchSettings settings)
    {
        booleanOperation.And().Group(group =>
        {
            INestedBooleanOperation? nestedBooleanOperation = null;

            foreach (var fieldType in textQuery.SearchableFields)
            {
                var searchField = _searchFields.GetRequiredSearchField(fieldType);

                if (fieldType == typeof(TitleField))
                    searchField.SetBoost(settings.ComputedTitleBoost);

                if (textQuery.Term.IsSingleWord)
                    BuildSingleWordTextQuery(textQuery, group, nestedBooleanOperation, searchField);
                else
                    BuiltMultipleWordsTextQuery(textQuery, group, nestedBooleanOperation, searchField, textQuery.Term.SplitWords);
            }

            return nestedBooleanOperation;
        });
    }

    private static void BuildSingleWordTextQuery(TextQuery textQuery, INestedQuery nestedQuery, INestedBooleanOperation? nestedBooleanOperation, SearchField searchField)
    {
        var searchTerms = new List<IExamineValue>
        {
            textQuery.Term.Value.Boost(textQuery.Term.Boost.Value + searchField.Boost.Value),
            textQuery.Term.Value.MultipleCharacterWildcard()
        };

        if (nestedBooleanOperation == null)
            nestedBooleanOperation = nestedQuery.GroupedOr(searchField, searchTerms.ToArray());
        else
            nestedBooleanOperation = nestedBooleanOperation.Or().GroupedOr(searchField, searchTerms.ToArray());
    }

    private static void BuiltMultipleWordsTextQuery(TextQuery textQuery, INestedQuery nestedQuery, INestedBooleanOperation? nestedBooleanOperation, SearchField searchField, string[] words)
    {
        var searchTerms = new List<IExamineValue>();

        foreach (var word in words)
        {
            if (word.InvariantEquals(words.Last()))
                searchTerms.Add(word.MultipleCharacterWildcard());
            else
                searchTerms.Add(word.Boost(textQuery.Term.Boost.Value + searchField.Boost.Value));
        }

        if (nestedBooleanOperation == null)
            nestedBooleanOperation = nestedQuery.GroupedAnd(searchField, searchTerms.ToArray());
        else
            nestedBooleanOperation = nestedBooleanOperation.Or().GroupedAnd(searchField, searchTerms.ToArray());
    }

    private void AddFilterQuery(IBooleanOperation examineQuery, FilterQuery filterQuery)
    {
        foreach (var kvp in filterQuery.Filters)
        {
            var searchField = _searchFields.GetRequiredSearchField(kvp.Key);
            var searchValue = kvp.Value;

            switch (searchValue)
            {
                case SingleValue singleValue:
                    examineQuery = examineQuery.And().SingleValueQuery(searchField, singleValue);
                    break;
                case MultiValue multiValue:
                    examineQuery = examineQuery.And().MultiValueQuery(searchField, multiValue);
                    break;
                case IRangeValue rangeValue:
                    examineQuery = examineQuery.And().RangeValueQuery(searchField, rangeValue);
                    break;
            }
        }
    }

    private void AddSortQuery(IBooleanOperation examineQuery, SortQuery orderQuery)
    {
        foreach (var kvp in orderQuery.SortableFields)
        {
            var searchField = _searchFields.GetRequiredSearchField(kvp.Key);
            var sortOrder = kvp.Value;

            switch (sortOrder)
            {
                case SortOrder.Asc:
                    examineQuery.OrderBy(searchField);
                    break;
                case SortOrder.Desc:
                    examineQuery.OrderByDescending(searchField);
                    break;
            }
        }
    }

    private ISearcher GetSearcher(bool preview)
    {
        var indexName = preview ? Umbraco.Cms.Core.Constants.UmbracoIndexes.InternalIndexName
                                : Umbraco.Cms.Core.Constants.UmbracoIndexes.ExternalIndexName;

        if (!_examineManager.TryGetIndex(indexName, out IIndex index))
            throw new InvalidOperationException($"No index found by name {indexName}");

        return index.Searcher;
    }
}