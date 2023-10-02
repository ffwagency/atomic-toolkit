using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = DoubleImage.ModelTypeAlias)]
public class DoubleImageViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(BlockListItem<DoubleImage> source)
	{
		return View("~/Views/Partials/blocklist/Components/DoubleImage.cshtml", source);
	}
}
