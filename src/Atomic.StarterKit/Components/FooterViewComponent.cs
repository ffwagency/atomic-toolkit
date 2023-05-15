using Atomic.Common.Content.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace AtomicStarterKit.Components;

[ViewComponent(Name = Footer.ModelTypeAlias)]
public class FooterViewComponent : ViewComponent
{
    private readonly MultisiteContentService _multisiteContentService;

    public FooterViewComponent(MultisiteContentService multisiteContentService)
    {
        _multisiteContentService = multisiteContentService;
    }
    public IViewComponentResult Invoke()
    {
        var sharedComponents = _multisiteContentService.GetSharedContent<Layout>();
        var footer = sharedComponents?.Footer?.FirstOrDefault()?.Content as Footer;
        return View("~/views/Components/Footer.cshtml", footer);
    }
}
