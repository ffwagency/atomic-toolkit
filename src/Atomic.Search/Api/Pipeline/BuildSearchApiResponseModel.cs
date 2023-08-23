using Atomic.Common.Content;
using Atomic.Common.Pagination;
using Atomic.Common.Pipelines;
using Atomic.Search.Api.Models.Response;
using Atomic.Search.Api.Models.Response.SearchResultProperties;
using Examine;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.Search.Api.Pipeline;

public class BuildSearchApiResponseModel : PipelineStep<SearchApiPipelineArgs>
{
    private readonly SearchApiResultPropertiesCollection _searchApiResultProperties;
    private readonly MultisiteContentService _multisiteContentService;

    public BuildSearchApiResponseModel(SearchApiResultPropertiesCollection searchApiResultProperties,
         MultisiteContentService multisiteContentService)
    {
        _searchApiResultProperties = searchApiResultProperties;
        _multisiteContentService = multisiteContentService;
    }

    public override void Process(SearchApiPipelineArgs args)
    {
        args.SearchResponseModel = BuildSearchResponseModel(args.ExamineSearchResults, args.UmbracoContext);
    }

    public SearchResponseModel BuildSearchResponseModel(PagedResult<ISearchResult> searchResults, IUmbracoContext umbracoContext)
    {
        var settings = _multisiteContentService.GetRequiredSettings<SearchSettings>();

        var searchApiResuls = new List<SearchApiResult>();

        foreach (var searchResult in searchResults.Results)
        {
            if (!int.TryParse(searchResult.Id, out int id))
                continue;

            var publishedContent = umbracoContext.Content!.GetById(id);
            if (publishedContent == null)
                continue;

            var searchApiResult = new SearchApiResult();

            AddDynamicProperties(searchApiResult, publishedContent, settings);
            AddScoreProperty(searchApiResult, searchResult);

            searchApiResuls.Add(searchApiResult);
        }

        return new SearchResponseModel(searchResults.PageNumber, searchResults.PageSize, searchApiResuls, searchResults.TotalResults);
    }

    private static void AddScoreProperty(SearchApiResult result, ISearchResult searchResult)
    {
        result["score"] = searchResult.Score;
    }

    private void AddDynamicProperties(SearchApiResult result, IPublishedContent publishedContent, SearchSettings settings)
    {
        foreach (var property in _searchApiResultProperties)
        {
            if (string.IsNullOrWhiteSpace(property.Name))
                continue;

            result[property.Name] = property.GetValue(publishedContent, settings);
        }
    }
}