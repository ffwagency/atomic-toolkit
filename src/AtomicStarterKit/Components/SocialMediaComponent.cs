using AtomicStarterKit.Common.Services;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace AtomicStarterKit.Components
{
	[ViewComponent(Name = "SocialMedia")]
	public class SocialMediaComponent : ViewComponent
	{
		private readonly ContentTreeNavigator _contentTreeNavigator;

		public SocialMediaComponent(ContentTreeNavigator contentTreeNavigator)
		{
			_contentTreeNavigator = contentTreeNavigator;
		}

		public IViewComponentResult Invoke()
		{
			var vm = _contentTreeNavigator.GetSettingsNode<SocialMediaSettings>();
			return View("~/Views/Components/SocialMedia.cshtml", vm);
		}
	}
}
