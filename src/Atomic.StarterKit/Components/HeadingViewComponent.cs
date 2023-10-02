using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Heading.ModelTypeAlias)]
public class HeadingViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(BlockListItem<Heading> source)
	{
		return View("~/Views/Partials/blocklist/Components/Heading.cshtml", source);
	}
}
