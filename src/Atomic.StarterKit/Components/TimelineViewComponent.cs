using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Timeline.ModelTypeAlias)]
public class TimelineViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(Timeline source)
	{
		return View("~/Views/Components/Timeline.cshtml", source);
	}
}
