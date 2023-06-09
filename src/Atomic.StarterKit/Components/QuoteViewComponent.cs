﻿using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Quote.ModelTypeAlias)]
public class QuoteViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(Quote source)
	{
		return View("~/Views/Components/Quote.cshtml", source);
	}
}
