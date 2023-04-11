using System.Text;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;
using AtomicStarterKit.Sео.Interfaces;

namespace AtomicStarterKit.Sео.MetatagsProviders
{
    public class FacebookSeoMetatagsProvider : ISeoMetatagsProvider
    {
        public string GetHtml(IPublishedContent page, SeoBackofficeManagableSettings seoSettings)
        {
            var sb = new StringBuilder();

            var title = page.Value<string>("socialMediaShareTitle");
            if (!string.IsNullOrWhiteSpace(title))
                sb.Append(@"<meta property=""og:title"" content=""").Append(title).AppendLine(@""" />");

            var description = page.Value<string>("socialMediaShareDescription");
            if (!string.IsNullOrWhiteSpace(description))
            {
                description = description.Truncate(190);
                sb.Append(@"<meta property=""og:description"" content=""").Append(description).AppendLine(@""" />");
            }

            var image = page.Value<MediaWithCrops>("socialMediaShareImage");
            if (image == null)
                image = seoSettings.SocialMediaShareDefaultImage;
            if (image != null)
                sb.Append(@"<meta property=""og:image"" content=""").Append(image.MediaUrl(null, UrlMode.Absolute)).AppendLine(@""" />");

            sb.Append(@"<meta property=""og:url"" content=""").Append(page.Url(Thread.CurrentThread.CurrentCulture.Name, UrlMode.Absolute)).AppendLine(@""" />");

            sb.AppendLine(@"<meta property=""og:type"" content=""website"" />");

            return sb.ToString();
        }
    }
}