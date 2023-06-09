using Atomic.OutputCache.Mvc.Controllers;
using Atomic.StarterKit.Models.Mapping;
using Atomic.StarterKit.ModelsBuilder.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Web;

namespace Atomic.StarterKit.Pages;

public class TeamMemberPageController : CachedRenderController
{
	public TeamMemberPageController(ILogger<TeamMemberPageController> logger,
							  ICompositeViewEngine compositeViewEngine,
							  IUmbracoContextAccessor umbracoContextAccessor)
		: base(logger, compositeViewEngine, umbracoContextAccessor)
	{ }

	public override IActionResult Index()
	{
        var vm = ((ITeamMemberPage)CurrentPage!).MapToDesignPageViewModel();
		return View("~/views/DefaultPage.cshtml", vm);
	}
}