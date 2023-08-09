using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Timeline.ModelTypeAlias)]
public class TimelineViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(BlockListItem<Timeline> source)
	{
		return View("~/Views/Partials/blocklist/Components/Timeline.cshtml", source);
	}
}
