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
public class AboutPageController : RenderController
{
	public AboutPageController(ILogger<AboutPageController> logger,
							  ICompositeViewEngine compositeViewEngine,
							  IUmbracoContextAccessor umbracoContextAccessor)
		: base(logger, compositeViewEngine, umbracoContextAccessor)
	{ }

	public override IActionResult Index()
	{
		var vm = ((AboutPage)CurrentPage).MapToDesignPageViewModel();
		return View("~/views/DefaultPage.cshtml", vm);
	}
}