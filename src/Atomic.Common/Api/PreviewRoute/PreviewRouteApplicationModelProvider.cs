using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Extensions;

namespace Atomic.Common.Api.PreviewRoute;

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
			if (!IsUmbracoApiControllerWithEnabledPreviewRoute(controller))
				continue;

			foreach (ActionModel action in controller.Actions)
				previewRouteConvention.Apply(action);
		}
	}

	private static bool IsUmbracoApiControllerWithEnabledPreviewRoute(ControllerModel controller)
	{
		return controller.ControllerType.Inherits<UmbracoApiController>()
			   && controller.Attributes.OfType<PreviewRouteAttribute>().Any();
	}
}