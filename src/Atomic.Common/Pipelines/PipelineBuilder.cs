using Umbraco.Cms.Core.Composing;

namespace Atomic.Common.Pipelines;

public class PipelineBuilder<TPipeline, TArgs>
    : OrderedCollectionBuilderBase<PipelineBuilder<TPipeline, TArgs>, TPipeline, PipelineStep<TArgs>>
    where TPipeline: Pipeline<TArgs>
    where TArgs : PipelineArgs
{
    protected override PipelineBuilder<TPipeline, TArgs> This => this;
}