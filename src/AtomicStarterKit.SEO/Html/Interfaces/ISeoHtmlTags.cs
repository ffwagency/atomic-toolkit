using Umbraco.Cms.Web.Common.PublishedModels;

namespace AtomicStarterKit.Sео.Html.Interfaces;

public interface ISeoHtmlTags
{
    string Get(ISeoBasePage page, SeoSettings seoSettings);
}