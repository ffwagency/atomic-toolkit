using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Microsoft.Extensions.Logging;
using Atomic.StarterKit.Models.Mapping;
using Atomic.OutputCache;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Pages;

public class ContactPageController : CachedAtomicController
{
	public ContactPageController(ILogger<ContactPageController> logger,
							  ICompositeViewEngine compositeViewEngine,
							  IUmbracoContextAccessor umbracoContextAccessor)
		: base(logger, compositeViewEngine, umbracoContextAccessor)
	{ }

	public override IActionResult Index()
	{
		var vm = ((ContactPage)CurrentPage!).MapToDesignPageViewModel();
		return View("~/views/DefaultPage.cshtml", vm);
	}
}