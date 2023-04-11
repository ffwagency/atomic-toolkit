using AtomicStarterKit.Sео.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Text;
using Umbraco.Cms.Core.Cache;
using Umbraco.Extensions;

namespace AtomicStarterKit.Sео.Controllers
{
    public class SeoController : Controller
    {
        public const string SiteMapCachePrefix = "SITEMAP";

        private readonly SeoService _seoService;
        private readonly IAppPolicyCache _runtimeCache;

        public SeoController(SeoService seoService, AppCaches caches)
        {
            _seoService = seoService;
            _runtimeCache = caches.RuntimeCache;
        }

        [Route("sitemap.xml")]
        public IActionResult SitemapXml()
        {
            var xml = _runtimeCache.GetCacheItem($"{SiteMapCachePrefix}_{Request.Host.Value}",
                                                 () => _seoService.GetSitemapXml(),
                                                 TimeSpan.FromHours(1));

            if (string.IsNullOrWhiteSpace(xml))
                return NotFound();

            return Content(xml, "text/xml", Encoding.UTF8);
        }

        [Route("robots.txt")]
        public IActionResult RobotsTxt()
        {
            var txt = _seoService.GetRobotsTxt();
            if (string.IsNullOrWhiteSpace(txt))
                return NotFound();

            return Content(txt, "text/plain", Encoding.UTF8);
        }
    }
}
