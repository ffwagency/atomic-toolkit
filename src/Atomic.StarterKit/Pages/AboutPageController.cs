using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.OutputCaching;
using Atomic.OutputCache;
using Atomic.StarterKit.Models.Mapping;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Pages;

[OutputCache(PolicyName = Constants.DefaultPolicy)]
public class AboutPageController : RenderController
{
	public AboutPageController(ILogger<AboutPageController> logger,
							  ICompositeViewEngine compositeViewEngine,
							  IUmbracoContextAccessor umbracoContextAccessor)
		: base(logger, compositeViewEngine, umbracoContextAccessor)
	{ }

	public override IActionResult Index()
	{
		var vm = ((AboutPage)CurrentPage!).MapToDesignPageViewModel();
		return View("~/views/DefaultPage.cshtml", vm);
	}
}