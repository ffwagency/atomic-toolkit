using Atomic.StarterKit.ModelsBuilder;
using Atomic.StarterKit.ModelsBuilder.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Constants.Aliases.Components.PortfolioListing)]
public class PortfolioListingViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(IPortfolioListing source)
	{
		return View("~/Views/Components/PortfolioListing.cshtml", source);
	}
}
