using Atomic.StarterKit.ModelsBuilder;
using Atomic.StarterKit.ModelsBuilder.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Constants.Aliases.Components.Gallery)]
public class GalleryViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(IGallery source)
	{
		return View("~/Views/Components/Gallery.cshtml", source);
	}
}
