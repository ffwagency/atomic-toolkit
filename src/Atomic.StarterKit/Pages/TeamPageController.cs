﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Microsoft.Extensions.Logging;
using Atomic.StarterKit.Models.Mapping;
using Atomic.StarterKit.ModelsBuilder.Interfaces;
using Atomic.OutputCache.Controllers;

namespace Atomic.StarterKit.Pages;

public class TeamPageController : CachedRenderController
{
	public TeamPageController(ILogger<TeamPageController> logger,
							  ICompositeViewEngine compositeViewEngine,
							  IUmbracoContextAccessor umbracoContextAccessor)
		: base(logger, compositeViewEngine, umbracoContextAccessor)
	{ }

	public override IActionResult Index()
	{
		var vm = ((ITeamPage)CurrentPage!).MapToDesignPageViewModel();
		return View("~/views/DefaultPage.cshtml", vm);
	}
}