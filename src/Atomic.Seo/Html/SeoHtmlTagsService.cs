using Atomic.Common.Configuration;
using Microsoft.AspNetCore.Html;
using Microsoft.Extensions.Options;
using System.Text;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.Seo.Html;

public class SeoHtmlTagsService
{
    private readonly SeoHtmlTagsCollection _seoHtmlTagsCollection;
    private readonly AtomicCommonOptions _options;

    public SeoHtmlTagsService(SeoHtmlTagsCollection seoHtmlTagsCollection,
        IOptions<AtomicCommonOptions> options)
    {
        _seoHtmlTagsCollection = seoHtmlTagsCollection;
        _options = options.Value;
    }

    public HtmlString GetHtmlTags(ISeoBasePage seoPage, SeoSettings seoSettings)
    {
        var html = new StringBuilder();

        foreach (var seoHtmlTags in _seoHtmlTagsCollection)
            html.AppendLine(seoHtmlTags.Get(seoPage, seoSettings, _options));

        return new HtmlString(html.ToString());
    }
}