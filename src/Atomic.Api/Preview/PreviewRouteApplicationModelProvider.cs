using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Atomic.Api.Preview;

public class PreviewRouteApplicationModelProvider : IApplicationModelProvider
{
	public int Order => 0;

	public void OnProvidersExecuted(ApplicationModelProviderContext context)
	{ }

	public void OnProvidersExecuting(ApplicationModelProviderContext context)
	{
		var previewRouteConvention = new PreviewRouteConvention();

		foreach (ControllerModel controller in context.Result.Controllers)
		{
			if (!controller.ControllerType.SupportsPreview())
				continue;

			foreach (ActionModel action in controller.Actions)
				previewRouteConvention.Apply(action);
		}
	}
}