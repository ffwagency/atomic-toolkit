using Atomic.OutputCache;
using Atomic.StarterKit.Models.Mapping;
using Atomic.StarterKit.ModelsBuilder.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace Atomic.StarterKit.Pages;

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
        var vm = ((IErrorPage)CurrentPage!).MapHeaderlessPageToDesignPageViewModel();
        return View("~/views/DefaultPage.cshtml", vm);
    }
}