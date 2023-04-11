using AtomicStarterKit.Models.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace AtomicStarterKit.Pages
{
	public class PortfolioSinglePageController : RenderController
	{
		public PortfolioSinglePageController(ILogger<PortfolioSinglePageController> logger,
								  ICompositeViewEngine compositeViewEngine,
								  IUmbracoContextAccessor umbracoContextAccessor)
			: base(logger, compositeViewEngine, umbracoContextAccessor)
		{ }

		public override IActionResult Index()
		{
			var vm = ((PortfolioSinglePage)CurrentPage).MapToDesignPage();
			return View("~/views/DefaultPage.cshtml", vm);
		}
	}
}