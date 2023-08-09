using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = FeaturedPortfolio.ModelTypeAlias)]
public class FeaturedPortfolioViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(BlockListItem<FeaturedPortfolio> source)
	{
		return View("~/Views/Partials/blocklist/Components/FeaturedPortfolio.cshtml", source);
	}
}