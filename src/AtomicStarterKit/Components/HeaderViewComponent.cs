using AtomicStarterKit.Common.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace AtomicStarterKit.Components
{
	[ViewComponent(Name = Header.ModelTypeAlias)]
	public class HeaderViewComponent : ViewComponent
	{
		private readonly ContentTreeNavigator _contentTreeNavigator;

		public HeaderViewComponent(ContentTreeNavigator contentTreeNavigator)
		{
			_contentTreeNavigator = contentTreeNavigator;
		}

		public IViewComponentResult Invoke()
		{
			var sharedComponents = _contentTreeNavigator.GetDataNode<Layout>();
			var header = sharedComponents?.Header?.FirstOrDefault()?.Content as Header;
			ViewData["currentUrl"] = Request.Path.Value;
			return View("~/Views/Components/Header.cshtml", header);
		}
	}
}
