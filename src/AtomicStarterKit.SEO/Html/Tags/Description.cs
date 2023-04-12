using AtomicStarterKit.Common.Content.Extensions;
using AtomicStarterKit.Sео.Html.Interfaces;
using StackExchange.Profiling.Internal;
using Umbraco.Cms.Web.Common.PublishedModels;
using Umbraco.Extensions;

namespace AtomicStarterKit.Sео.Html.Tags;

public class Description : ISeoHtmlTags
{
    public virtual string Get(ISeoBasePage seoPage, SeoSettings seoSettings)
    {
        var description = seoPage.MetaDescription;
        if (string.IsNullOrWhiteSpace(description))
            description = seoPage.GetValueWithFallback<string>(seoSettings.TextFallback);

        if (string.IsNullOrWhiteSpace(description))
            return string.Empty;

        description = description.StripHtml()
                                 .RemoveNewLines()
                                 .Truncate(seoSettings.MetaDescriptionMaxLength != 0
                                           ? seoSettings.MetaDescriptionMaxLength
                                           : 150);

        return $@"<meta name=""description"" content=""{description}"">{Environment.NewLine}";
    }
}