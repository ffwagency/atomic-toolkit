using Atomic.Common.Pipelines;
using Atomic.Search.Querying;

namespace Atomic.Search.Api.Pipeline;

public class BuildFilterQuery : PipelineStep<SearchApiPipelineArgs>
{
    public override void Process(SearchApiPipelineArgs args)
    {
        foreach (var filter in args.SearchRequestModel.Filter)
            args.FilterQuery.Add(filter.Key, filter.Value.ToSearchValue());
    }
}