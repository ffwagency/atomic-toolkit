using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace AtomicStarterKit.Components;

[ViewComponent(Name = ClientsWall.ModelTypeAlias)]
public class ClientsWallViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(ClientsWall source)
	{
		return View("~/Views/Components/ClientsWall.cshtml", source);
	}
}
