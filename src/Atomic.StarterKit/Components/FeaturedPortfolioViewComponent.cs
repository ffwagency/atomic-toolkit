using Atomic.StarterKit.ModelsBuilder;
using Atomic.StarterKit.ModelsBuilder.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Constants.Aliases.Components.FeaturedPortfolio)]
public class FeaturedPortfolioViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(IFeaturedPortfolio source)
	{
		return View("~/Views/Components/FeaturedPortfolio.cshtml", source);
	}
}
