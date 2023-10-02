using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Services.ModelTypeAlias)]
public class ServicesViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(BlockListItem<Services> source)
	{
		return View("~/Views/Partials/blocklist/Components/Services.cshtml", source);
	}
}
