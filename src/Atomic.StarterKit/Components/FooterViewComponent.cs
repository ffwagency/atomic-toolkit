using Atomic.Common.Content;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

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
		var footer = sharedComponents?.Footer?.FirstOrDefault();
		return View("~/Views/Partials/blocklist/Components/Footer.cshtml", footer);
	}
}