﻿using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace AtomicStarterKit.Components;

[ViewComponent(Name = Contact.ModelTypeAlias)]
public class ContactViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(Contact source)
	{
		return View("~/views/Components/Contact.cshtml", source);
	}
}
