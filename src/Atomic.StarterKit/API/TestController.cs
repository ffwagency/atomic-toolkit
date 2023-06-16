using Atomic.OutputCache;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.API
{
	public class TestController : CachedAtomicApiController
	{
		[Route("darko/help")]
		public ActionResult Now()
		{
			var a = UmbracoContext.Content.GetAtRoot().First() as HomePage;
			return Ok(a.BrowserTitle);
		}
	}
}