using Atomic.Common.Multilanguage;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Atomic.Api;

public class SetContextCultureAttribute : ActionFilterAttribute
{
	public override void OnActionExecuting(ActionExecutingContext context)
	{
		var query = context.HttpContext.Request.Query;

		var options = context.HttpContext.RequestServices.GetRequiredService<IOptions<AtomicApiOptions>>().Value;

		foreach (var param in options.ApiParamsAffectingContextCulture)
		{
			if (query.TryGetValue(param, out var culture))
			{
				var culturesService = context.HttpContext.RequestServices.GetRequiredService<CulturesService>();
				culturesService.PushContextCulture(culture!);
				break;
			}
		}
	}
}