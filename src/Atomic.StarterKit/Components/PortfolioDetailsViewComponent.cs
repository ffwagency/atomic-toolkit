using Atomic.StarterKit.ModelsBuilder;
using Atomic.StarterKit.ModelsBuilder.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Constants.Aliases.Components.PortfolioDetails)]
public class PortfolioDetailsViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(IPortfolioDetails source)
	{
		return View("~/Views/Components/PortfolioDetails.cshtml", source);
	}
}
