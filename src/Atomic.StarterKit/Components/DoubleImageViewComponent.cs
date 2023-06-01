using Atomic.StarterKit.ModelsBuilder;
using Atomic.StarterKit.ModelsBuilder.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Constants.Aliases.Components.DoubleImage)]
public class DoubleImageViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(IDoubleImage source)
	{
		return View("~/Views/Components/DoubleImage.cshtml", source);
	}
}
