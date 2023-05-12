﻿using AtomicStarterKit.Models.Mapping;
using AtomicStarterKit.OutputCache;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace AtomicStarterKit.Pages;

[OutputCache(PolicyName = Constants.DefaultPolicy)]
public class ContentPageController : RenderController
{
	public ContentPageController(ILogger<ContentPageController> logger,
							  ICompositeViewEngine compositeViewEngine,
							  IUmbracoContextAccessor umbracoContextAccessor)
		: base(logger, compositeViewEngine, umbracoContextAccessor)
	{ }

	public override IActionResult Index()
	{
		var vm = ((ContentPage)CurrentPage).MapToDesignPageViewModel();
		return View("~/views/DefaultPage.cshtml", vm);
	}
}