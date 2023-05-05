using AtomicStarterKit.Models.Mapping;
using AtomicStarterKit.Umbraco.OutputCache;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace AtomicStarterKit.Pages;

[OutputCache(PolicyName = CachingConstants.DefaultPolicy)]
public class TeamMemberPageController : RenderController
{
	public TeamMemberPageController(ILogger<TeamMemberPageController> logger,
							  ICompositeViewEngine compositeViewEngine,
							  IUmbracoContextAccessor umbracoContextAccessor)
		: base(logger, compositeViewEngine, umbracoContextAccessor)
	{ }

	public override IActionResult Index()
	{
		var vm = ((TeamMemberPage)CurrentPage).MapToDesignPageViewModel();
		return View("~/views/DefaultPage.cshtml", vm);
	}
}