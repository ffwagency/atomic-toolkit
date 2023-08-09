using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Hero.ModelTypeAlias)]
public class HeroViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(BlockListItem<Hero> source)
	{
		return View("~/Views/Partials/blocklist/Components/Hero.cshtml", source);
	}
}