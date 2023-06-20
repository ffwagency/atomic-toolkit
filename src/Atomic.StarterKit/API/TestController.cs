using Atomic.OutputCache;
using Microsoft.AspNetCore.Mvc;

namespace Atomic.StarterKit.API
{
	public class TestController : CachedAtomicApiController
	{
		[Route("gosho/e/pich")]
		public ActionResult Now()
		{
			return Ok("TEST");
		}
	}
}
