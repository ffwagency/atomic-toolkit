using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;
using AtomicStarterKit.Sео.Interfaces;

namespace AtomicStarterKit.Sео.MetatagsProviders
{
    public class NoIndexNoFollowSeoMetatagsProvider : ISeoMetatagsProvider
    {
        public string GetHtml(IPublishedContent page, SeoBackofficeManagableSettings seoSettings)
        {
            var index = "index";
            var follow = "follow";

            if (page.Value<bool>("noIndex") || page.Name == "404")
                index = $"no{index}";
            if (page.Value<bool>("noFollow") || page.Name == "404")
                follow = $"no{follow}";

            return $@"<meta name=""robots"" content=""{index}, {follow}"">";
        }
    }
}