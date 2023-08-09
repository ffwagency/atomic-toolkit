using Atomic.Common.Content;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

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
		var header = sharedComponents?.Header?.FirstOrDefault();
		ViewData["currentUrl"] = Request.Path.Value;
		return View("~/Views/Partials/blocklist/Components/Header.cshtml", header);
	}
}
