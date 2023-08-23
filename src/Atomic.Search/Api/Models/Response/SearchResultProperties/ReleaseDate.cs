using Atomic.Api.Response;
using Atomic.Common.Content;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.Search.Api.Models.Response.SearchResultProperties;

public class ReleaseDate : ISearchApiResultProperty
{
    public string Name => "releaseDate";

    public object? GetValue(IPublishedContent publishedContent, SearchSettings settings)
    {
        var releaseDate = publishedContent.GetValueWithFallback<DateTime>(settings.ApiResultReleaseDate);
        if (releaseDate == DateTime.MinValue)
            releaseDate = publishedContent.CreateDate;
        return releaseDate.ToISO8601();
    }
}