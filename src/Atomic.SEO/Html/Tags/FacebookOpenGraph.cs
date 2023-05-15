using Atomic.Common.Content.Extensions;
using AtomicStarterKit.Sео.Common.Extensions;
using AtomicStarterKit.Sео.Html.Interfaces;
using System.Text;
using Umbraco.Cms.Web.Common.PublishedModels;
using Umbraco.Extensions;

namespace AtomicStarterKit.Sео.Html.Tags;

public class FacebookOpenGraph : ISeoHtmlTags
{
    public virtual string Get(ISeoBasePage seoPage, SeoSettings seoSettings)
    {
        var html = new StringBuilder();

        var shareTitle = seoPage.GetShareTitle(seoSettings);
        html.AppendLine(@$"<meta property=""og:title"" content=""{shareTitle}"">");

        var shareText = seoPage.GetShareText(seoSettings);
        if (!string.IsNullOrWhiteSpace(shareText))
        {
			shareText = shareText.StripHtml()
                                     .RemoveNewLines()
                                     .Truncate(seoSettings.ShareTextMaxLength != 0
                                               ? seoSettings.ShareTextMaxLength
											   : 190);

            html.AppendLine(@$"<meta property=""og:description"" content=""{shareText}"">");
        }

        var shareImage = seoPage.GetShareImageAbsoluteUrl(seoSettings);
        if (!string.IsNullOrWhiteSpace(shareImage))
            html.AppendLine(@$"<meta property=""og:image"" content=""{shareImage}"">");

        var url = seoPage.GetAbsoluteUrl();
        html.AppendLine(@$"<meta property=""og:url"" content=""{url}"">");

        html.AppendLine(@"<meta property=""og:type"" content=""website"" />");

        return html.ToString();
    }
}