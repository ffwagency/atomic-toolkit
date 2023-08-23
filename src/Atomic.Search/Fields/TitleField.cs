using Umbraco.Cms.Core.Models.PublishedContent;
using Examine;
using Atomic.Common.Content;
using Umbraco.Cms.Web.Common.PublishedModels;
using Atomic.Search.Fields.Base;

namespace Atomic.Search.Fields;

public class TitleField : SearchComputedField
{
    public TitleField() : base("computed_title", true)
    { }

    public override string Type => FieldDefinitionTypes.FullText;

    public override string Key => "title";

    public override object? ComputeValue(IPublishedContent indexedContent, SearchSettings settings, string? culture = null)
    {
        var title = indexedContent.GetValueWithFallback<string>(settings.ComputedTitle, culture);
        return string.IsNullOrWhiteSpace(title) ? null : title;
    }
}