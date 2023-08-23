using Umbraco.Cms.Core.DependencyInjection;

namespace Atomic.Common.Pipelines;

public static class IUmbracoBuilderExtensions
{
    public static  PipelineBuilder<TPipeline, TArgs> ConfigurePipeline<TPipeline, TArgs>(this IUmbracoBuilder builder)
        where TPipeline: Pipeline<TArgs>
        where TArgs : PipelineArgs
        => builder.WithCollectionBuilder<PipelineBuilder<TPipeline, TArgs>>();
}