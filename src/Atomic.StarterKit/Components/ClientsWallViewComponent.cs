using Atomic.StarterKit.ModelsBuilder;
using Atomic.StarterKit.ModelsBuilder.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Constants.Aliases.Components.ClientsWall)]
public class ClientsWallViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(IClientsWall source)
	{
		return View("~/Views/Components/ClientsWall.cshtml", source);
	}
}
