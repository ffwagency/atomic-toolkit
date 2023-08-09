using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Gallery.ModelTypeAlias)]
public class GalleryViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(BlockListItem<Gallery> source)
	{
		return View("~/Views/Partials/blocklist/Components/Gallery.cshtml", source);
	}
}
