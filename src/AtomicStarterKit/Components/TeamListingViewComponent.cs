using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace AtomicStarterKit.Components
{
	[ViewComponent(Name = TeamListing.ModelTypeAlias)]
	public class TeamListingViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke(TeamListing source)
		{
			return View("~/Views/Components/TeamListing.cshtml", source);
		}
	}
}
