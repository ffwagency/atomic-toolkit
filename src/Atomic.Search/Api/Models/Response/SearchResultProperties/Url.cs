using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;
using Umbraco.Extensions;

namespace Atomic.Search.Api.Models.Response.SearchResultProperties;

public class Url : ISearchApiResultProperty
{
    public string Name => "url";

    public object? GetValue(IPublishedContent publishedContent, SearchSettings settings)
    {
        return publishedContent.Url(null, UrlMode.Absolute);
    }
}