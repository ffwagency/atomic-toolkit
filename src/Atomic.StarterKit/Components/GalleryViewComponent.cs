using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace AtomicStarterKit.Components;

[ViewComponent(Name = Gallery.ModelTypeAlias)]
public class GalleryViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(Gallery source)
	{
		return View("~/Views/Components/Gallery.cshtml", source);
	}
}
