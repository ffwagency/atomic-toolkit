using Atomic.Common.Configuration;
using Atomic.Search.Api.Models.Response.SearchResultProperties;
using Atomic.Search.Api.Pipeline;
using Atomic.Search.Fields;
using Atomic.Search.Querying;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.DependencyInjection;

namespace Atomic.Search.DependencyInjection;

public static class IUmbracoBuilderExtensions
{
    internal static IUmbracoBuilder AddAtomicSearch(this IUmbracoBuilder builder)
    {
        builder.AddAtomicOptions<AtomicSearchOptions>();
        builder.Services.AddSingleton<SearchService>();

        builder.ConfigureSearchFields();
        builder.ConfigureSearchApiPipeline();
        builder.ConfigureSearchApiResultProperties();

        return builder;
    }
}