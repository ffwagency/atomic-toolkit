using Atomic.StarterKit.ModelsBuilder;
using Atomic.StarterKit.ModelsBuilder.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Constants.Aliases.Components.Contact)]
public class ContactViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(IContact source)
	{
		return View("~/views/Components/Contact.cshtml", source);
	}
}
