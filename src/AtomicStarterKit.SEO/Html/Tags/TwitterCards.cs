using System.Text;
using Umbraco.Extensions;
using Umbraco.Cms.Web.Common.PublishedModels;
using AtomicStarterKit.Sео.Html.Interfaces;
using AtomicStarterKit.Common.Content.Extensions;
using AtomicStarterKit.Sео.Common.Extensions;

namespace AtomicStarterKit.Sео.Html.Tags;

public class TwitterCards : ISeoHtmlTags
{
    public virtual string Get(ISeoBasePage seoPage, SeoSettings seoSettings)
    {
        var html = new StringBuilder();

        var shareTitle = seoPage.GetShareTitle(seoSettings);
        html.AppendLine(@$"<meta property=""twitter:title"" content=""{shareTitle}"">");

        var shareText = seoPage.GetShareText(seoSettings);
        if (!string.IsNullOrWhiteSpace(shareText))
        {
            shareText = shareText.StripHtml()
                                     .RemoveNewLines()
                                     .Truncate(seoSettings.ShareTextMaxLength != 0
                                               ? seoSettings.ShareTextMaxLength
											   : 190);

            html.AppendLine(@$"<meta property=""twitter:description"" content=""{shareText}"">");
        }

        var shareImage = seoPage.GetShareImageAbsoluteUrl(seoSettings);
        if (!string.IsNullOrWhiteSpace(shareImage))
            html.AppendLine(@$"<meta property=""twitter:image"" content=""{shareImage}"">");

        html.AppendLine(@"<meta property=""twitter:card"" content=""summary"" />");

        return html.ToString();
    }
}