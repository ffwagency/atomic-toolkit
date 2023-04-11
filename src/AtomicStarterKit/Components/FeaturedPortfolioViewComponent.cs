﻿using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace AtomicStarterKit.Components
{
	[ViewComponent(Name = FeaturedPortfolio.ModelTypeAlias)]
	public class FeaturedPortfolioViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke(FeaturedPortfolio source)
		{
			return View("~/Views/Components/FeaturedPortfolio.cshtml", source);
		}
	}
}
