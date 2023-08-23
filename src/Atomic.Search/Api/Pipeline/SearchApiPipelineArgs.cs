using Atomic.Common.Pagination;
using Atomic.Common.Pipelines;
using Atomic.Search.Api.Models.Request;
using Atomic.Search.Api.Models.Response;
using Atomic.Search.Querying;
using Examine;
using Umbraco.Cms.Core.Web;

namespace Atomic.Search.Api.Pipeline;

public class SearchApiPipelineArgs : PipelineArgs
{
    public SearchApiPipelineArgs(SearchRequestModel searchRequestModel, IUmbracoContext umbracoContext)
    {
        SearchRequestModel = searchRequestModel;
        UmbracoContext = umbracoContext;
        TextQuery = TextQuery.Empty;
        FilterQuery = FilterQuery.Empty;
        SortQuery = SortQuery.Empty;
        ExamineSearchResults = PagedResult<ISearchResult>.Empty(searchRequestModel.PageNumber, searchRequestModel.PageSize);
        SearchResponseModel = SearchResponseModel.Empty(searchRequestModel.PageNumber, searchRequestModel.PageSize);
    }

    public SearchRequestModel SearchRequestModel { get; }

    public IUmbracoContext UmbracoContext { get; }

    public TextQuery TextQuery { get; }

    public FilterQuery FilterQuery { get; }

    public SortQuery SortQuery { get; }

    public PagedResult<ISearchResult> ExamineSearchResults { get; set; }

    public SearchResponseModel SearchResponseModel { get; set; }
}