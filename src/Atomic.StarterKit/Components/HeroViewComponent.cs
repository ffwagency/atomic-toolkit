using Atomic.StarterKit.ModelsBuilder;
using Atomic.StarterKit.ModelsBuilder.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Constants.Aliases.Components.Hero)]
public class HeroViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(IHero source)
	{
		return View("~/Views/Components/Hero.cshtml", source);
	}
}
