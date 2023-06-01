using Atomic.Common.Content.Services;
using Atomic.StarterKit.ModelsBuilder;
using Atomic.StarterKit.ModelsBuilder.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Constants.Aliases.Components.SocialMedia)]
public class SocialMediaComponent : ViewComponent
{
	private readonly MultisiteContentService _multisiteContentService;

	public SocialMediaComponent(MultisiteContentService multisiteContentService)
	{
		_multisiteContentService = multisiteContentService;
	}

	public IViewComponentResult Invoke()
	{
		var vm = _multisiteContentService.GetSettings<ISocialMediaSettings>();
		return View("~/Views/Components/SocialMedia.cshtml", vm);
	}
}
