using Atomic.Common.Pipelines;

namespace Atomic.Search.Api.Pipeline;

public class BuildSortQuery : PipelineStep<SearchApiPipelineArgs>
{
    public override void Process(SearchApiPipelineArgs args)
    {
        args.SortQuery.SortBy(args.SearchRequestModel.SortBy,
                              args.SearchRequestModel.SortOrder);
    }
}