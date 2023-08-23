using Atomic.Common.Pipelines;

namespace Atomic.Search.Api.Pipeline;

public class BuildTextQuery : PipelineStep<SearchApiPipelineArgs>
{
    public override void Process(SearchApiPipelineArgs args)
    {
        args.TextQuery.SetSearchTerm(args.SearchRequestModel.Term);
    }
}