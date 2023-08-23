using Atomic.Common.Pipelines;

namespace Atomic.Search.Api.Pipeline
{
    public class SearchApiPipeline : Pipeline<SearchApiPipelineArgs>
    {
        public SearchApiPipeline(Func<IEnumerable<PipelineStep<SearchApiPipelineArgs>>> items)
            : base(items)
        { }
    }
}
