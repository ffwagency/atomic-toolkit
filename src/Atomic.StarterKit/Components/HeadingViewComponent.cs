using Atomic.StarterKit.ModelsBuilder;
using Atomic.StarterKit.ModelsBuilder.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Constants.Aliases.Components.Heading)]
public class HeadingViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(IHeading source)
	{
		return View("~/Views/Components/Heading.cshtml", source);
	}
}
