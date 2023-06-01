using Atomic.StarterKit.ModelsBuilder;
using Atomic.StarterKit.ModelsBuilder.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Constants.Aliases.Components.CTA)]
public class CTAViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(ICTA source)
	{
		return View("~/Views/Components/CTA.cshtml", source);
	}
}
