using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.OutputCaching;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Extensions;

namespace Atomic.OutputCache.Mvc.ApplicationModels;

public class AtomicOutputCacheApplicationModelProvider : IApplicationModelProvider
{
	private readonly IActionModelConvention[] _actionModelConventions;

	public AtomicOutputCacheApplicationModelProvider()
	{
		_actionModelConventions = new[]
		{
			new PreviewRouteConvention()
		};
	}

	public int Order => 0;

	public void OnProvidersExecuted(ApplicationModelProviderContext context)
	{ }

	public void OnProvidersExecuting(ApplicationModelProviderContext context)
	{
		foreach (ControllerModel controller in context.Result.Controllers)
		{
			if (!IsCachedUmbracoApiController(controller))
				continue;

			foreach (ActionModel action in controller.Actions)
				foreach (var actionModelConventions in _actionModelConventions)
					actionModelConventions.Apply(action);
		}
	}

	private static bool IsCachedUmbracoApiController(ControllerModel controller)
	{
		return controller.Attributes.OfType<OutputCacheAttribute>().Any() 
			   && controller.ControllerType.Inherits<UmbracoApiController>();
	}
}