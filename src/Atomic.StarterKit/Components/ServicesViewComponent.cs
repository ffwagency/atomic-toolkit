using Atomic.StarterKit.ModelsBuilder;
using Atomic.StarterKit.ModelsBuilder.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Constants.Aliases.Components.Services)]
public class ServicesViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(IServices source)
	{
		return View("~/Views/Components/Services.cshtml", source);
	}
}
