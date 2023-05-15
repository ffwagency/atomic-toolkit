using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace AtomicStarterKit.Components;

[ViewComponent(Name = Services.ModelTypeAlias)]
public class ServicesViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(Services source)
	{
		return View("~/Views/Components/Services.cshtml", source);
	}
}
