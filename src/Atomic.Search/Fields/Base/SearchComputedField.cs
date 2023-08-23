using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;
using Umbraco.Extensions;

namespace Atomic.Search.Fields.Base;

public abstract class SearchComputedField : SearchField
{
    protected SearchComputedField(string examineNameWithoutCulture,
        bool varyByCulture,
        float? boost = null)
        : base(examineNameWithoutCulture, varyByCulture, boost)
    { }

    public abstract string Type { get; }

    public virtual Dictionary<string, object[]> GetFieldValue(IPublishedContent? publishedContent, SearchSettings settings)
    {
        var result = new Dictionary<string, object[]>();

        if (publishedContent == null)
            return result;

        if (VaryByCulture && publishedContent.ContentType.VariesByCulture())
        {
            foreach (var culture in publishedContent.Cultures.Keys)
            {
                var value = ComputeValue(publishedContent, settings, culture);
                if (value != null)
                    result.TryAdd($"{ExamineNameWithoutCulture}_{culture.ToLower()}", new[] { value });
            }
        }
        else
        {
            var value = ComputeValue(publishedContent, settings, null);
            if (value != null)
                result.TryAdd(ExamineNameWithoutCulture, new[] { value });
        }

        return result;
    }

    public abstract object? ComputeValue(IPublishedContent publishedContent, SearchSettings settings, string? culture = null);
}