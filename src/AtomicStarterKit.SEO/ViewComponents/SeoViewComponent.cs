using AtomicStarterKit.Sео.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Options;
using System;
using Umbraco.Cms.Core.Web;

namespace AtomicStarterKit.Sео.ViewComponents
{
    [ViewComponent(Name = "Seo")]
    public class SeoViewComponent : ViewComponent
    {
        private readonly SeoService _seoService;
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;

        public SeoViewComponent(SeoService seoService, IUmbracoContextAccessor umbracoContextAccessor)
        {
            _seoService = seoService;
            _umbracoContextAccessor = umbracoContextAccessor;
        }

        public IViewComponentResult Invoke()
        {
            if (!_umbracoContextAccessor.TryGetUmbracoContext(out var umbracoContext))
                throw new ArgumentNullException(nameof(umbracoContext));

            var html = _seoService.GetPageSeoHtml(umbracoContext.PublishedRequest.PublishedContent);
            return new HtmlContentViewComponentResult(html);
        }
    }
}
