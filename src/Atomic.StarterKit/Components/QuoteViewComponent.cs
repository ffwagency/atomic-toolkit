using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Quote.ModelTypeAlias)]
public class QuoteViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(BlockListItem<Quote> source)
	{
		return View("~/Views/Partials/blocklist/Components/Quote.cshtml", source);
	}
}
