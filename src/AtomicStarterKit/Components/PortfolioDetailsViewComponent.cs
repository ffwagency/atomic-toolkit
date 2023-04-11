using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace AtomicStarterKit.Components
{
	[ViewComponent(Name = PortfolioDetails.ModelTypeAlias)]
	public class PortfolioDetailsViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke(PortfolioDetails source)
		{
			return View("~/Views/Components/PortfolioDetails.cshtml", source);
		}
	}
}
