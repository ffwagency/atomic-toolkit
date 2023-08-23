using Atomic.Common.Content;
using Atomic.Search.Fields.Base;
using Examine;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;
using Umbraco.Extensions;

namespace Atomic.Search.Fields;

public class InheritsSearchBasePage : SearchComputedField
{
    public const string Yes = "y";

    public InheritsSearchBasePage() : base("computed_inheritsSearchBasePage", false)
    { }

    public override string Type => FieldDefinitionTypes.FullText;

    public override object? ComputeValue(IPublishedContent publishedContent, SearchSettings settings, string? culture = null)
    {
        return publishedContent.ContentType.CompositionAliases.Any(x => x.InvariantEquals(SearchBasePage.ModelTypeAlias))
            ? Yes
            : null;
    }
}