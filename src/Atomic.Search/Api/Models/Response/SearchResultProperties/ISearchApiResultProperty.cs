using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.Search.Api.Models.Response.SearchResultProperties;

public interface ISearchApiResultProperty
{
    string Name { get; }

    object? GetValue(IPublishedContent publishedContent, SearchSettings settings);
}