﻿using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Atomic.Common.Api.PreviewRoute;

namespace Atomic.OutputCache.Controllers;

[OutputCache]
[PreviewRoute]
public class CachedRenderController : RenderController
{
    public CachedRenderController(ILogger<RenderController> logger,
        ICompositeViewEngine compositeViewEngine,
        IUmbracoContextAccessor umbracoContextAccessor)
        : base(logger, compositeViewEngine, umbracoContextAccessor)
    { }

    public override IActionResult Index()
    {
        return CurrentTemplate(CurrentPage);
    }
}
