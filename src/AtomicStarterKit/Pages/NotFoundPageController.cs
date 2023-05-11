using AtomicStarterKit.Umbraco.OutputCache;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace AtomicStarterKit.Pages;

[OutputCache(PolicyName = CachingConstants.DefaultPolicy)]
public class NotFoundPageController : RenderController
{
	public NotFoundPageController(ILogger<NotFoundPageController> logger,
							  ICompositeViewEngine compositeViewEngine,
							  IUmbracoContextAccessor umbracoContextAccessor)
		: base(logger, compositeViewEngine, umbracoContextAccessor)
	{ }

	public override IActionResult Index()
	{
		return View("~/views/404.cshtml");
	}
}
