using Atomic.StarterKit.ModelsBuilder;
using Atomic.StarterKit.ModelsBuilder.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Constants.Aliases.Components.Timeline)]
public class TimelineViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(ITimeline source)
	{
		return View("~/Views/Components/Timeline.cshtml", source);
	}
}
