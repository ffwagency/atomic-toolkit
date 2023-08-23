using Umbraco.Cms.Core.Models.PublishedContent;
using Examine;
using Atomic.Common.Content;
using Umbraco.Cms.Web.Common.PublishedModels;
using Examine.Search;
using Atomic.Search.Fields.Base;

namespace Atomic.Search.Fields;

public class ReleaseDateField : SearchComputedField, ISortable
{
    public ReleaseDateField() : base("computed_releaseDate", true)
    { }

    public override string Type => FieldDefinitionTypes.Long;

    public override string Key => "releaseDate";

    public SortType SortType => SortType.Long;

    public override object? ComputeValue(IPublishedContent indexedContent, SearchSettings settings, string? culture = null)
    {
        var releaseDate = indexedContent.GetValueWithFallback<DateTime>(settings.ComputedReleaseDate, culture);
        return releaseDate == DateTime.MinValue
            ? indexedContent.CreateDate.Ticks
            : releaseDate.Ticks;
    }
}