﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.OutputCaching;
using Atomic.OutputCache;
using Atomic.Skeleton.Models.Mapping;

namespace Atomic.Skeleton.Pages;

[OutputCache(PolicyName = Constants.DefaultPolicy)]
public class HomePageController : RenderController
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