﻿using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = PortfolioListing.ModelTypeAlias)]
public class PortfolioListingViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(PortfolioListing source)
	{
		return View("~/Views/Components/PortfolioListing.cshtml", source);
	}
}
