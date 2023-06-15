using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = CTA.ModelTypeAlias)]
public class CTAViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(CTA source)
	{
		return View("~/Views/Components/CTA.cshtml", source);
	}
}
