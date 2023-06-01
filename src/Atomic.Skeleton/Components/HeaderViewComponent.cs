using Atomic.Common.Content.Services;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.Skeleton.Components;

[ViewComponent(Name = Header.ModelTypeAlias)]
public class HeaderViewComponent : ViewComponent
{
    private readonly MultisiteContentService _multisiteContentService;

    public HeaderViewComponent(MultisiteContentService multisiteContentService)
    {
        _multisiteContentService = multisiteContentService;
    }

    public IViewComponentResult Invoke()
    {
        var sharedComponents = _multisiteContentService.GetSharedContent<Layout>();
        var header = sharedComponents?.Header?.FirstOrDefault()?.Content as Header;
        ViewData["currentUrl"] = Request.Path.Value;
        return View("~/Views/Components/Header.cshtml", header);
    }
}