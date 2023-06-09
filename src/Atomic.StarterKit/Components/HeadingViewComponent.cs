﻿using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Heading.ModelTypeAlias)]
public class HeadingViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(Heading source)
	{
		return View("~/Views/Components/Heading.cshtml", source);
	}
}
