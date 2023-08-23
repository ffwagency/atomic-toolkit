using Atomic.Common.Content;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;
using Umbraco.Extensions;

namespace Atomic.Search.Api.Models.Response.SearchResultProperties;

public class Text : ISearchApiResultProperty
{
    public string Name => "text";

    public object? GetValue(IPublishedContent publishedContent, SearchSettings settings)
    {
        var textValues = publishedContent.CollectValues<string>(settings.ApiResultText);
        var text = string.Join(" ", textValues).StripHtml().RemoveNewLines();
        if (string.IsNullOrWhiteSpace(text))
            return null;

        if (settings.ApiResultTextMaxLength > 0)
            text = text.Truncate(settings.ApiResultTextMaxLength);

        return text;
    }
}