using Atomic.Common.Configuration;
using Atomic.Common.Content;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.Search.Api.Models.Response.SearchResultProperties;

public class Image : ISearchApiResultProperty
{
    private readonly AtomicCommonOptions _options;

    public Image(IOptions<AtomicCommonOptions> options)
    {
        _options = options.Value;
    }

    public string Name => "image";

    public object? GetValue(IPublishedContent publishedContent, SearchSettings settings)
    {
        var image = publishedContent.GetValueWithFallback<MediaWithCrops>(settings.ApiResultImage);
        if (image == null)
            return null;

        return string.IsNullOrWhiteSpace(settings.ApiResultImageCrop)
            ? image.AtomicMediaUrl(_options, null, UrlMode.Absolute, settings.ApiResultImageQuality, settings.ApiResultConvertToWebP)
            : image.AtomicMediaCropUrl(_options, settings.ApiResultImageCrop, UrlMode.Absolute, settings.ApiResultImageQuality, settings.ApiResultConvertToWebP);
    }
}