using Atomic.StarterKit.ModelsBuilder;
using Atomic.StarterKit.ModelsBuilder.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Constants.Aliases.Components.TeamListing)]
public class TeamListingViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(ITeamListing source)
	{
		return View("~/Views/Components/TeamListing.cshtml", source);
	}
}
