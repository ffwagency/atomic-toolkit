using Atomic.Common.Content;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = "SocialMedia")]
public class SocialMediaComponent : ViewComponent
{
	private readonly MultisiteContentService _multisiteContentService;

	public SocialMediaComponent(MultisiteContentService multisiteContentService)
	{
		_multisiteContentService = multisiteContentService;
	}

	public IViewComponentResult Invoke()
	{
		var vm = _multisiteContentService.GetSettings<SocialMediaSettings>();
		return View("~/Views/Partials/blocklist/Components/SocialMedia.cshtml", vm);
	}
}