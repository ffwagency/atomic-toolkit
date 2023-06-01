using Atomic.StarterKit.ModelsBuilder;
using Atomic.StarterKit.ModelsBuilder.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Constants.Aliases.Components.Quote)]
public class QuoteViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(IQuote source)
	{
		return View("~/Views/Components/Quote.cshtml", source);
	}
}
