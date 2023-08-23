using Umbraco.Cms.Core.Models.PublishedContent;
using Examine;
using Umbraco.Cms.Web.Common.PublishedModels;
using Atomic.Search.Fields.Base;

namespace Atomic.Search.Fields;

public class PathField : SearchComputedField
{
    public PathField() : base("computed_path", false)
    { }

    public override string Type => FieldDefinitionTypes.FullText;

    public override object? ComputeValue(IPublishedContent publishedContent, SearchSettings settings, string? culture = null)
    {
        return publishedContent.Path.Replace(",", " ");
    }
}