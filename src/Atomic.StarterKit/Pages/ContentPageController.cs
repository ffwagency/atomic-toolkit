using Atomic.OutputCache.Controllers;
using Atomic.StarterKit.Models.Mapping;
using Atomic.StarterKit.ModelsBuilder.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Web;

namespace Atomic.StarterKit.Pages;

public class ContentPageController : CachedRenderController
{
	public ContentPageController(ILogger<ContentPageController> logger,
							  ICompositeViewEngine compositeViewEngine,
							  IUmbracoContextAccessor umbracoContextAccessor)
		: base(logger, compositeViewEngine, umbracoContextAccessor)
	{ }

	public override IActionResult Index()
	{
		var vm = ((IContentPage)CurrentPage!).MapToDesignPageViewModel();
		return View("~/views/DefaultPage.cshtml", vm);
	}
}