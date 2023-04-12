using AtomicStarterKit.Common.Content.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace AtomicStarterKit.Sео.RobotsTxt.Controllers;

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

    [Route(Constants.RobotsTxt.Route)]
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