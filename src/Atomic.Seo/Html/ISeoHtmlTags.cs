using Atomic.Common.Configuration;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.Seo.Html;

public interface ISeoHtmlTags
{
    string Get(ISeoBasePage page, SeoSettings seoSettings, AtomicCommonOptions options);
}