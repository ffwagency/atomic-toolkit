using AtomicStarterKit.Common.Content.Extensions;
using AtomicStarterKit.Sео.Html.Interfaces;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace AtomicStarterKit.Sео.Html.Tags;

public class Title : ISeoHtmlTags
{
    public virtual string Get(ISeoBasePage seoPage, SeoSettings seoSettings)
    {
        var title = seoPage.BrowserTitle;
        if (string.IsNullOrWhiteSpace(title))
            title = seoPage.GetValueWithFallback<string>(seoSettings.TitleFallback);
        if (string.IsNullOrWhiteSpace(title))
            title = seoPage.Name;

        return $"<title>{title}</title>{Environment.NewLine}";
    }
}