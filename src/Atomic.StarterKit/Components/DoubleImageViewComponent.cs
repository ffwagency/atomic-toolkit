using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = DoubleImage.ModelTypeAlias)]
public class DoubleImageViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(DoubleImage source)
	{
		return View("~/Views/Components/DoubleImage.cshtml", source);
	}
}
