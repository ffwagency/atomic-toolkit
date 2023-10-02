using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Error.ModelTypeAlias)]
public class ErrorViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(BlockListItem<Error> source)
    {
        return View("~/Views/Partials/blocklist/Components/Error.cshtml", source);
    }
}