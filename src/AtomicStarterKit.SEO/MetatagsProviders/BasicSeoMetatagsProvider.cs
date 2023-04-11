using System.Text;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;
using AtomicStarterKit.Sео.Interfaces;

namespace AtomicStarterKit.Sео.MetatagsProviders
{
    public class BasicSeoMetatagsProvider : ISeoMetatagsProvider
    {
        public string GetHtml(IPublishedContent page, SeoBackofficeManagableSettings seoSettings)
        {
            var sb = new StringBuilder();

            var browserTitle = page.Value<string>("browserTitle");
            if (string.IsNullOrWhiteSpace(browserTitle))
                browserTitle = page.Name(Thread.CurrentThread.CurrentCulture.ToString());
            if (!string.IsNullOrWhiteSpace(browserTitle))
                sb.Append("<title>").Append(browserTitle).AppendLine("</title>");

            var metaDescription = page.Value<string>("metaDescription");
            if (!string.IsNullOrWhiteSpace(metaDescription))
            {
                metaDescription = metaDescription.Truncate(150);
                sb.Append(@"<meta name=""description"" content=""").Append(metaDescription).AppendLine(@""">");
            }

            var metaKeywords = page.Value<IEnumerable<string>>("metaKeywords")?.ToList();
            if (metaKeywords?.Count > 0)
                sb.Append(@"<meta name=""keywords"" content=""").Append(string.Join(",", metaKeywords)).AppendLine(@""">");

            return sb.ToString();
        }
    }
}