using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = CTA.ModelTypeAlias)]
public class CTAViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(BlockListItem<CTA> source)
	{
		return View("~/Views/Partials/blocklist/Components/CTA.cshtml", source);
	}
}
