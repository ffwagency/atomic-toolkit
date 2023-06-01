using Atomic.StarterKit.ModelsBuilder;
using Atomic.StarterKit.ModelsBuilder.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = Constants.Aliases.Components.TeamMemberDetails)]
public class TeamMemberDetailsViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(ITeamMemberDetails source)
	{
		return View("~/Views/Components/TeamMemberDetails.cshtml", source);
	}
}
