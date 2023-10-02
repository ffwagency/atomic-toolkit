using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = ClientsWall.ModelTypeAlias)]
public class ClientsWallViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(BlockListItem<ClientsWall> source)
	{
		return View("~/Views/Partials/blocklist/Components/ClientsWall.cshtml", source);
	}
}
