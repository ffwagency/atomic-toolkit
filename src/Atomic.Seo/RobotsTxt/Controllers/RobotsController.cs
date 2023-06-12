using Atomic.Common.Content.Services;
using Umbraco.Cms.Web.Common.PublishedModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Umbraco.Cms.Core.Web;

namespace Atomic.Sео.RobotsTxt.Controllers;

public class RobotsController : Controller
{
	private readonly MultisiteContentService _multisiteContentService;
	private readonly IUmbracoContextFactory _umbracoContextFactory;

	public RobotsController(MultisiteContentService multisiteContentService,
		IUmbracoContextFactory umbracoContextFactory)
	{
		_multisiteContentService = multisiteContentService;
		_umbracoContextFactory = umbracoContextFactory;
	}

	[Route(Constants.Route)]
	public IActionResult RobotsTxt()
	{
		using (var umbracoContextRef = _umbracoContextFactory.EnsureUmbracoContext())
		{
			var seoSettings = _multisiteContentService.GetSettings<SeoSettings>();

			if (seoSettings == null)
				return StatusCode(StatusCodes.Status503ServiceUnavailable);
			if (seoSettings.TurnOffSeo)
				return StatusCode(StatusCodes.Status503ServiceUnavailable);
			if (string.IsNullOrWhiteSpace(seoSettings.RobotsTxt))
				return StatusCode(StatusCodes.Status503ServiceUnavailable);

			return Content(seoSettings.RobotsTxt, "text/plain", Encoding.UTF8);
		}
	}
}