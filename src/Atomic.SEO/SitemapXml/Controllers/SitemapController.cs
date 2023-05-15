using Atomic.Common.Content.Services;
using AtomicStarterKit.Sео.SitemapXml.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;
using Umbraco.Extensions;

namespace AtomicStarterKit.Sео.SitemapXml.Controllers;

public class SitemapController : Controller
{
    private const string SitemapCachePrefix = "Sitemap_";

    private readonly MultisiteContentService _multisiteContentService;
    private readonly IAppPolicyCache _runtimeCache;
    private readonly IUmbracoContextFactory _umbracoContextFactory;
    private readonly SitemapService _sitemapService;

    public SitemapController(MultisiteContentService multisiteContentService,
        AppCaches appCaches,
        IUmbracoContextFactory umbracoContextFactory,
        SitemapService sitemapService)
    {
        _multisiteContentService = multisiteContentService;
        _runtimeCache = appCaches.RuntimeCache;
        _umbracoContextFactory = umbracoContextFactory;
        _sitemapService = sitemapService;
    }

    [Route(Constants.SitemapXml.Route)]
    public IActionResult SitemapXml()
    {
        using (var umbracoContextRef = _umbracoContextFactory.EnsureUmbracoContext())
        {
            var seoSettings = _multisiteContentService.GetSettings<SeoSettings>();

            if (seoSettings == null)
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            if (seoSettings.TurnOffSeo)
                return StatusCode(StatusCodes.Status503ServiceUnavailable);

            var websiteRoot = _multisiteContentService.GetWebsiteRoot<ISeoBasePage>();
            if (websiteRoot == null)
                return StatusCode(StatusCodes.Status503ServiceUnavailable);

            var sitemapXml = string.Empty;

            if (seoSettings.TurnOffSitemapCache)
                sitemapXml = _sitemapService.GetSitemapXml(websiteRoot);
            else
                sitemapXml = _runtimeCache.GetCacheItem(SitemapCachePrefix + Request.Host.Value,
                                                 () => _sitemapService.GetSitemapXml(websiteRoot),
                                                 TimeSpan.FromHours(seoSettings.SitemapCacheDuration != 0
                                                                    ? seoSettings.SitemapCacheDuration
                                                                    : 1));

            if (string.IsNullOrWhiteSpace(sitemapXml))
                return StatusCode(StatusCodes.Status503ServiceUnavailable);

            return Content(sitemapXml, "text/xml", Encoding.UTF8);
        }
    }
}