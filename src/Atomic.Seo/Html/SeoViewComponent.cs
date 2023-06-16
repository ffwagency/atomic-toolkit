using Umbraco.Cms.Web.Common.PublishedModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Umbraco.Cms.Core.Web;
using Atomic.Common.Content;

namespace Atomic.Sео.Html;

[ViewComponent(Name = Constants.SeoViewComponentName)]
public class SeoViewComponent : ViewComponent
{
    private readonly SeoHtmlTagsService _seoHtmlTagsService;
    private readonly IUmbracoContextAccessor _umbracoContextAccessor;
    private readonly MultisiteContentService _multisiteContentService;

    public SeoViewComponent(SeoHtmlTagsService seoHtmlTagsService,
        IUmbracoContextAccessor umbracoContextAccessor,
        MultisiteContentService multisiteContentService)
    {
        _seoHtmlTagsService = seoHtmlTagsService;
        _umbracoContextAccessor = umbracoContextAccessor;
        _multisiteContentService = multisiteContentService;
    }

    public IViewComponentResult Invoke()
    {
        var seoSettings = _multisiteContentService.GetSettings<SeoSettings>();

        if (seoSettings == null)
            return Content(string.Empty);
        if (seoSettings.TurnOffSeo)
            return Content(string.Empty);
        if (!_umbracoContextAccessor.TryGetUmbracoContext(out var umbracoContext))
            return Content(string.Empty);
        if (umbracoContext.PublishedRequest?.PublishedContent is not ISeoBasePage seoPage)
            return Content(string.Empty);

        var html = _seoHtmlTagsService.GetHtmlTags(seoPage, seoSettings);

        return new HtmlContentViewComponentResult(html);
    }
}
