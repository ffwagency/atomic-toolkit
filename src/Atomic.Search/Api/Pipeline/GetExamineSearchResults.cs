using Atomic.Common.Pipelines;
using Atomic.Search.Querying;

namespace Atomic.Search.Api.Pipeline;

public class GetExamineSearchResults : PipelineStep<SearchApiPipelineArgs>
{
    private readonly SearchService _searchService;

    public GetExamineSearchResults(SearchService searchService)
    {
        _searchService = searchService;
    }

    public override void Process(SearchApiPipelineArgs args)
    {
        var searchQuery = new SearchQuery(args.SearchRequestModel.PageNumber,
                                          args.SearchRequestModel.PageSize,
                                          args.TextQuery,
                                          args.FilterQuery,
                                          args.SortQuery);

        args.ExamineSearchResults = _searchService.Search(searchQuery, args.UmbracoContext.InPreviewMode);
    }
}
