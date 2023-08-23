using Atomic.Common.Content;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;
using Umbraco.Extensions;

namespace Atomic.Search.Api.Models.Response.SearchResultProperties;

public class Title : ISearchApiResultProperty
{
    public string Name => "title";

    public object? GetValue(IPublishedContent publishedContent, SearchSettings settings)
    {
        var title = publishedContent.GetValueWithFallback<string>(settings.ApiResultTitle);
        if (string.IsNullOrWhiteSpace(title))
            return null;

        if (settings.ApiResultTitleMaxLength > 0)
            title = title.Truncate(settings.ApiResultTitleMaxLength);

        return title;
    }
}