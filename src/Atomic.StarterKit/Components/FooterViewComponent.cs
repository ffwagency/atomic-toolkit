using Atomic.Common.Content.Services;
using Atomic.StarterKit.ModelsBuilder;
using Atomic.StarterKit.ModelsBuilder.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Constants.Aliases.Components.Footer)]
public class FooterViewComponent : ViewComponent
{
	private readonly MultisiteContentService _multisiteContentService;

	public FooterViewComponent(MultisiteContentService multisiteContentService)
	{
		_multisiteContentService = multisiteContentService;
	}
	public IViewComponentResult Invoke()
	{
		var sharedComponents = _multisiteContentService.GetSharedContent<ILayout>();
		var footer = sharedComponents?.Footer?.FirstOrDefault()?.Content as IFooter;
		return View("~/views/Components/Footer.cshtml", footer);
	}
}
