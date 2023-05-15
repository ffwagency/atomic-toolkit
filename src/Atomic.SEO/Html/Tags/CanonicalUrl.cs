using Umbraco.Cms.Web.Common.PublishedModels;
using AtomicStarterKit.Sео.Html.Interfaces;
using AtomicStarterKit.Sео.Common.Extensions;

namespace AtomicStarterKit.Sео.Html.Tags;

public class CanonicalUrl : ISeoHtmlTags
{
    public virtual string Get(ISeoBasePage seoPage, SeoSettings seoSettings)
    {
        var url = seoPage.GetAbsoluteUrl();
        return $@"<link rel=""canonical"" href=""{url}"">{Environment.NewLine}";
    }
}