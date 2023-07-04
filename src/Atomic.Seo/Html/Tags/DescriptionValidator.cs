namespace Atomic.Seo.Html.Tags;

internal static class DescriptionValidator
{
    internal static bool HasDescription(this string? text)
    {
        return !string.IsNullOrWhiteSpace(text);
    }

    internal static bool HasMetaDescriptionMaxLengthDefined(this int metaDescriptionMaxLength)
    {
        return metaDescriptionMaxLength != 0;
    }
}
