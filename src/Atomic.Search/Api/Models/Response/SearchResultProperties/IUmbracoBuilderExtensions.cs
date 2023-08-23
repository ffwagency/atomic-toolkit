using Umbraco.Cms.Core.DependencyInjection;

namespace Atomic.Search.Api.Models.Response.SearchResultProperties;

public static class IUmbracoBuilderExtensions
{
    public static SearchApiResultPropertiesCollectionBuilder SearchApiResultProperties(this IUmbracoBuilder builder)
        => builder.WithCollectionBuilder<SearchApiResultPropertiesCollectionBuilder>();

    internal static IUmbracoBuilder ConfigureSearchApiResultProperties(this IUmbracoBuilder builder)
    {
        builder.SearchApiResultProperties()
          .Append<Title>()
          .Append<Text>()
          .Append<Url>()
          .Append<ReleaseDate>()
          .Append<Image>();

        return builder;
    }
}