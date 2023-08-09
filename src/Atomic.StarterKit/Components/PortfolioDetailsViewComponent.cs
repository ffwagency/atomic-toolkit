using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = PortfolioDetails.ModelTypeAlias)]
public class PortfolioDetailsViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(BlockListItem<PortfolioDetails> source)
	{
		return View("~/Views/Partials/blocklist/Components/PortfolioDetails.cshtml", source);
	}
}