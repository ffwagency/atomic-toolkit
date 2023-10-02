using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Components;

[ViewComponent(Name = TeamMemberDetails.ModelTypeAlias)]
public class TeamMemberDetailsViewComponent : ViewComponent
{
	public IViewComponentResult Invoke(BlockListItem<TeamMemberDetails> source)
	{
		return View("~/Views/Partials/blocklist/Components/TeamMemberDetails.cshtml", source);
	}
}