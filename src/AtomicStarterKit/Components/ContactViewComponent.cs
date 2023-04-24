using AtomicStarterKit.Models;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace AtomicStarterKit.Components;

[ViewComponent(Name = Contact.ModelTypeAlias)]
public class ContactViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(Contact source)
	{
		var vm = new ContactModel();
		vm.Contact = source;
		vm.ContactFormModel = new ContactFormViewModel();
		return View("~/views/Components/Contact.cshtml", vm);
	}
}
