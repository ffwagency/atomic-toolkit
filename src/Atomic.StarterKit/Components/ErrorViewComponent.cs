using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Error.ModelTypeAlias)]
public class ErrorViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(Error source)
    {
        return View("~/views/Components/Error.cshtml", source);
    }
}