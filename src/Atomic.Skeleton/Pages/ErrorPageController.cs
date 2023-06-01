﻿using Atomic.OutputCache;
using Atomic.Skeleton.Models.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.Skeleton.Pages;

[OutputCache(PolicyName = Constants.DefaultPolicy)]
public class ErrorPageController : RenderController
{
    public ErrorPageController(ILogger<ErrorPageController> logger,
                              ICompositeViewEngine compositeViewEngine,
                              IUmbracoContextAccessor umbracoContextAccessor)
        : base(logger, compositeViewEngine, umbracoContextAccessor)
    { }

    public override IActionResult Index()
    {
        var vm = ((ErrorPage)CurrentPage!).MapToDesignPageViewModel();
        return View("~/views/DefaultPage.cshtml", vm);
    }
}