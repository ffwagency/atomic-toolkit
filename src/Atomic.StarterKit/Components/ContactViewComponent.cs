using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Contact.ModelTypeAlias)]
public class ContactViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(BlockListItem<Contact> source)
	{
		return View("~/Views/Partials/blocklist/Components/Contact.cshtml", source);
	}
}
