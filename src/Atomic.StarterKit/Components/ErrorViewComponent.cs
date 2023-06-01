using Atomic.StarterKit.ModelsBuilder;
using Atomic.StarterKit.ModelsBuilder.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Constants.Aliases.Components.Error)]
public class ErrorViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(IError source)
    {
        return View("~/views/Components/Error.cshtml", source);
    }
}