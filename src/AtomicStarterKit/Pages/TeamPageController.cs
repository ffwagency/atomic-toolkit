using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;
using Microsoft.Extensions.Logging;
using AtomicStarterKit.Models.Mapping;
using AtomicStarterKit.Umbraco.OutputCache;
using Microsoft.AspNetCore.OutputCaching;

namespace AtomicStarterKit.Pages;

[OutputCache(PolicyName = CachingConstants.DefaultPolicy)]
public class TeamPageController : RenderController
{
	public TeamPageController(ILogger<TeamPageController> logger,
							  ICompositeViewEngine compositeViewEngine,
							  IUmbracoContextAccessor umbracoContextAccessor)
		: base(logger, compositeViewEngine, umbracoContextAccessor)
	{ }

	public override IActionResult Index()
	{
		var vm = ((TeamPage)CurrentPage).MapToDesignPageViewModel();
		return View("~/views/DefaultPage.cshtml", vm);
	}
}