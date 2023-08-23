using Umbraco.Cms.Core.Models.PublishedContent;
using Examine;
using Atomic.Common.Content;
using Umbraco.Extensions;
using Umbraco.Cms.Web.Common.PublishedModels;
using Atomic.Search.Fields.Base;

namespace Atomic.Search.Fields;

public class TextField : SearchComputedField
{
    public TextField() : base("computed_text", true)
    { }

    public override string Type => FieldDefinitionTypes.FullText;

    public override string Key => "text";

    public override object? ComputeValue(IPublishedContent indexedContent, SearchSettings settings, string? culture = null)
    {
        var textValues = indexedContent.CollectValues<string>(settings.ComputedText, culture);
        var text = string.Join(" ", textValues).StripHtml().RemoveNewLines();
        return string.IsNullOrWhiteSpace(text) ? null : text;
    }
}