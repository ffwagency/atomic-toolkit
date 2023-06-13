using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = TeamMemberDetails.ModelTypeAlias)]
public class TeamMemberDetailsViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(TeamMemberDetails source)
	{
		return View("~/Views/Components/TeamMemberDetails.cshtml", source);
	}
}