using System.Text;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;
using AtomicStarterKit.Sео.Interfaces;

namespace AtomicStarterKit.Sео.MetatagsProviders
{
    public class TwitterSeoMetatagsProvider : ISeoMetatagsProvider
    {
        public string GetHtml(IPublishedContent page, SeoBackofficeManagableSettings seoSettings)
        {
            var sb = new StringBuilder();

            var title = page.Value<string>("socialMediaShareTitle");
            if (!string.IsNullOrWhiteSpace(title))
                sb.Append(@"<meta property=""twitter:title"" content=""").Append(title).AppendLine(@""" />");

            var description = page.Value<string>("socialMediaShareDescription");
            if (!string.IsNullOrWhiteSpace(description))
            {
                description = description.Truncate(190);
                sb.Append(@"<meta property=""twitter:description"" content=""").Append(description).AppendLine(@""" />");
            }

            var image = page.Value<MediaWithCrops>("socialMediaShareImage");
            if (image == null)
                image = seoSettings.SocialMediaShareDefaultImage;
            if (image != null)
                sb.Append(@"<meta property=""twitter:image"" content=""").Append(image.MediaUrl(null, UrlMode.Absolute)).AppendLine(@""" />");

            sb.AppendLine(@"<meta property=""twitter:card"" content=""summary"" />");

            return sb.ToString();
        }
    }
}