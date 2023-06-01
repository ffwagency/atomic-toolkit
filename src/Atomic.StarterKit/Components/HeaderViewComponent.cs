using Atomic.Common.Content.Services;
using Atomic.StarterKit.ModelsBuilder;
using Atomic.StarterKit.ModelsBuilder.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Constants.Aliases.Components.Header)]
public class HeaderViewComponent : ViewComponent
{
	private readonly MultisiteContentService _multisiteContentService;

	public HeaderViewComponent(MultisiteContentService multisiteContentService)
	{
		_multisiteContentService = multisiteContentService;
	}

	public IViewComponentResult Invoke()
	{
		var sharedComponents = _multisiteContentService.GetSharedContent<ILayout>();
		var header = sharedComponents?.Header?.FirstOrDefault()?.Content as IHeader;
		ViewData["currentUrl"] = Request.Path.Value;
		return View("~/Views/Components/Header.cshtml", header);
	}
}
