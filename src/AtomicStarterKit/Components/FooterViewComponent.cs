using AtomicStarterKit.Common.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace AtomicStarterKit.Components
{
	[ViewComponent(Name = Footer.ModelTypeAlias)]
	public class FooterViewComponent : ViewComponent
	{
		private readonly ContentTreeNavigator _contentTreeNavigator;

		public FooterViewComponent(ContentTreeNavigator contentTreeNavigator)
		{
			_contentTreeNavigator = contentTreeNavigator;
		}
		public IViewComponentResult Invoke()
		{
			var sharedComponents = _contentTreeNavigator.GetDataNode<Layout>();
			var footer = sharedComponents?.Footer?.FirstOrDefault()?.Content as Footer;
			return View("~/views/Components/Footer.cshtml", footer);
		}
	}
}
