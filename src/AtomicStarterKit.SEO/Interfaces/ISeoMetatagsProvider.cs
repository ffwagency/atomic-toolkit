using Umbraco.Cms.Core.Models.PublishedContent;

namespace AtomicStarterKit.Sео.Interfaces
{
    public interface ISeoMetatagsProvider
    {
        string GetHtml(IPublishedContent page, SeoBackofficeManagableSettings seoSettings);
    }
}