using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Hero.ModelTypeAlias)]
public class HeroViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(Hero source)
	{
		return View("~/Views/Components/Hero.cshtml", source);
	}
}