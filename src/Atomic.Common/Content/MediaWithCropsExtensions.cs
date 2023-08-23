using Atomic.Common.Configuration;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Atomic.Common.Content;

public static class MediaWithCropsExtensions
{
    public static string? AtomicMediaUrl(this MediaWithCrops media,
        AtomicCommonOptions options,
        string? culture = null,
        UrlMode mode = UrlMode.Default,
        int? imageQuality = null,
        bool? convertToWebP = null)
    {
        var url = media.MediaUrl(culture, mode);
        url = ConfigureQuality(url, options.MediaOptions, imageQuality, convertToWebP);
        return url;
    }

    public static string? AtomicMediaScaledUrl(this MediaWithCrops media,
       AtomicCommonOptions options,
       ScaleType scaleType,
       int maxSize,
       string? culture = null,
       UrlMode mode = UrlMode.Default,
       int? imageQuality = null,
       bool? convertToWebP = null)
    {
        var url = media.MediaUrl(culture, mode);
        url = ConfigureScaling(url, scaleType, maxSize);
        url = ConfigureQuality(url, options.MediaOptions, imageQuality, convertToWebP);
        return url;
    }

    public static string? AtomicMediaCropUrl(this MediaWithCrops media,
       AtomicCommonOptions options,
       string cropAlias,
       UrlMode mode = UrlMode.Default,
       int? imageQuality = null,
       bool? convertToWebP = null)
    {
        var url = media.GetCropUrl(cropAlias, mode);
        return ConfigureQuality(url, options.MediaOptions, imageQuality, convertToWebP);
    }

    private static string? ConfigureQuality(string? url, MediaOptions options, int? imageQuality, bool? convertToWebP)
    {
        if (string.IsNullOrWhiteSpace(url))
            return url;

        var queryToAppend = string.Empty;

        if (imageQuality == null || imageQuality.Value == 0)
            imageQuality = options.DefaultImageQuality;

        if (imageQuality > 0 && imageQuality <= 100)
            queryToAppend += $"quality={imageQuality}";

        convertToWebP ??= options.ConvertToWebP;

        if (convertToWebP.Value && string.IsNullOrWhiteSpace(queryToAppend))
            queryToAppend += "format=webp";
        else if (convertToWebP.Value && !string.IsNullOrWhiteSpace(queryToAppend))
            queryToAppend += "&format=webp";

        if (string.IsNullOrWhiteSpace(queryToAppend))
            return url;

        if (url.Contains('?'))
            return $"{url}&{queryToAppend}";
        else
            return $"{url}?{queryToAppend}";
    }

    private static string? ConfigureScaling(string? url, ScaleType scaleType, int maxSize)
    {
        if (string.IsNullOrWhiteSpace(url))
            return url;

        var queryToAppend = "rmode=min"; // don't scale up smaller images

        switch (scaleType)
        {
            case ScaleType.Width:
                queryToAppend += $"&width={maxSize}";
                break;
            case ScaleType.Height:
                queryToAppend += $"&height={maxSize}";
                break;
        }

        if (url.Contains('?'))
            return $"{url}&{queryToAppend}";
        else
            return $"{url}?{queryToAppend}";
    }
}

public enum ScaleType
{
    Width,
    Height,
}