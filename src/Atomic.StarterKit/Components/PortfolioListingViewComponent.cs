using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = PortfolioListing.ModelTypeAlias)]
public class PortfolioListingViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(BlockListItem<PortfolioListing> source)
	{
		return View("~/Views/Partials/blocklist/Components/PortfolioListing.cshtml", source);
	}
}
