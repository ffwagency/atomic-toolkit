using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = TeamListing.ModelTypeAlias)]
public class TeamListingViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(BlockListItem<TeamListing> source)
	{
		return View("~/Views/Partials/blocklist/Components/TeamListing.cshtml", source);
	}
}