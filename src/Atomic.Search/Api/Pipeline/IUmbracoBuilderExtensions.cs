using Atomic.Common.Pipelines;
using Umbraco.Cms.Core.DependencyInjection;

namespace Atomic.Search.Api.Pipeline;

public static class IUmbracoBuilderExtensions
{
    internal static IUmbracoBuilder ConfigureSearchApiPipeline(this IUmbracoBuilder builder)
    {
        builder.ConfigurePipeline<SearchApiPipeline, SearchApiPipelineArgs>()
            .Append<BuildTextQuery>()
            .Append<BuildFilterQuery>()
            .Append<BuildSortQuery>()
            .Append<GetExamineSearchResults>()
            .Append<BuildSearchApiResponseModel>();

        return builder;
    }
}