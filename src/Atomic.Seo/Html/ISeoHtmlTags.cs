using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.Sео.Html;

public interface ISeoHtmlTags
{
    string Get(ISeoBasePage page, SeoSettings seoSettings);
}