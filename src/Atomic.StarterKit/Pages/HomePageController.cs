using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Microsoft.Extensions.Logging;
using Atomic.StarterKit.Models.Mapping;
using Umbraco.Cms.Web.Common.PublishedModels;
using Atomic.OutputCache;

namespace Atomic.StarterKit.Pages;

public class HomePageController : CachedRenderController
{
	public HomePageController(ILogger<HomePageController> logger,
							  ICompositeViewEngine compositeViewEngine,
							  IUmbracoContextAccessor umbracoContextAccessor)
		: base(logger, compositeViewEngine, umbracoContextAccessor)
	{ }

	public override IActionResult Index()
	{
		var vm = ((HomePage)CurrentPage!).MapToDesignPageViewModel();
		return View("~/views/DefaultPage.cshtml", vm);
	}
}