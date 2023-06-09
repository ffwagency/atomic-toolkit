﻿using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Reflection;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.Common.Attributes;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Extensions;

namespace Atomic.Api.Preview;

public class PreviewRouteConvention : IActionModelConvention
{
	private const string UmbracoApiDefaultRouteArea = "Api";
	private const int PreviewAttributeRouteOrder = 1000; // Higher number means low priority. We don't want this to be the default picked route.


	public static string BuildPreviewRoute(string defaultRoute)
	{
		defaultRoute = CleanDefaultUmbracoStartPath(defaultRoute);
		return $"{Common.Backoffice.Constants.PreviewRelativeUrlStartPath}{defaultRoute.EnsureStartsWith('/')}";
	}

	private static string CleanDefaultUmbracoStartPath(string defaultRoute)
	{
		defaultRoute = defaultRoute.EnsureStartsWith('/');

		if (defaultRoute.InvariantStartsWith(Common.Backoffice.Constants.UmbracoAuthorizedApiRelativeUrlStartPath))
			defaultRoute = defaultRoute.Replace(Common.Backoffice.Constants.UmbracoAuthorizedApiRelativeUrlStartPath, string.Empty, StringComparison.OrdinalIgnoreCase);
		if (defaultRoute.InvariantStartsWith(Common.Backoffice.Constants.UmbracoRelativeUrlStartPath))
			defaultRoute = defaultRoute.Replace(Common.Backoffice.Constants.UmbracoRelativeUrlStartPath, string.Empty, StringComparison.OrdinalIgnoreCase);

		return defaultRoute;
	}

	public void Apply(ActionModel action)
	{
		if (AddPreviewRouteWhenAttributeRoutingIsUsed(action))
			return;

		AddPreviewRouteWhenDefaultRoutingIsUsed(action);
	}

	private static bool AddPreviewRouteWhenAttributeRoutingIsUsed(ActionModel action)
	{
		var addedPrevewRoute = false;

		var controller = action.Controller;

		var controllerRoutesFromAttributes = GetControllerRoutesFromAttributes(controller).ToArray();

		if (controllerRoutesFromAttributes.Any())
		{
			foreach (var route in controllerRoutesFromAttributes)
			{
				var previewSelector = BuildPreviewSelectorModel(route);
				controller.Selectors.Add(previewSelector);
				addedPrevewRoute = true;
			}
		}
		else
		{
			var actionRoutesFromAttributes = GetActionRoutesFromAttributes(action).ToArray();
			if (actionRoutesFromAttributes.Any())
			{
				foreach (var route in actionRoutesFromAttributes.ToArray())
				{
					var previewSelector = BuildPreviewSelectorModel(route);
					action.Selectors.Add(previewSelector);
					addedPrevewRoute = true;
				}
			}
		}

		return addedPrevewRoute;
	}

	private static void AddPreviewRouteWhenDefaultRoutingIsUsed(ActionModel action)
	{
		var umbracoApiDefaultRoute = GetUmbracoApiDefaultRoute(action);

		if (string.IsNullOrWhiteSpace(umbracoApiDefaultRoute))
			return;

		action.Selectors.Clear(); // remove the default routing because otherwise we get an error that controller "defines attribute routed actions and non attribute routed actions"

		var defaultSelector = BuildDefaultSelectorModel(umbracoApiDefaultRoute);
		action.Selectors.Add(defaultSelector);

		var previewSelector = BuildPreviewSelectorModel(umbracoApiDefaultRoute);
		action.Selectors.Add(previewSelector);
	}

	private static IEnumerable<string> GetControllerRoutesFromAttributes(ControllerModel controller)
	{
		return controller.Selectors
						 .Where(x => x.AttributeRouteModel != null && !IsPreviewRouteAttribute(x.AttributeRouteModel))
						 .Select(x => x.AttributeRouteModel!.Template!)
						 .Where(x => !string.IsNullOrWhiteSpace(x));
	}

	private static IEnumerable<string> GetActionRoutesFromAttributes(ActionModel action)
	{
		return action.Selectors
					 .Where(x => x.AttributeRouteModel != null && !IsPreviewRouteAttribute(x.AttributeRouteModel))
					 .Select(x => x.AttributeRouteModel!.Template!)
					 .Where(x => !string.IsNullOrWhiteSpace(x));
	}

	private static SelectorModel BuildPreviewSelectorModel(string route)
	{
		var previewRouteTemplate = BuildPreviewRoute(route);

		return new SelectorModel
		{
			AttributeRouteModel = new AttributeRouteModel
			{
				Name = nameof(EnablePreviewAttribute),
				Order = PreviewAttributeRouteOrder,
				Template = previewRouteTemplate
			}
		};
	}

	private static SelectorModel BuildDefaultSelectorModel(string route)
	{
		return new SelectorModel
		{
			AttributeRouteModel = new AttributeRouteModel
			{
				Template = route
			}
		};
	}

	private static bool IsPreviewRouteAttribute(AttributeRouteModel attributeRouteModel)
	{
		return attributeRouteModel.Name.InvariantEquals(nameof(EnablePreviewAttribute));
	}

	private static string? GetUmbracoApiDefaultRoute(ActionModel action)
	{
		var controller = action.Controller;
		var controllerName = action.Controller.ControllerName;
		var actionName = action.ActionName;

		if (IsUmbracoAuthorizedApiController(controller))
			return $"{Common.Backoffice.Constants.UmbracoAuthorizedApiRelativeUrlStartPath}/{GetUmbracoApiDefaultRouteArea(controller)}/{controllerName}/{actionName}";
		if (IsUmbracoNotAuthorizedApiController(controller))
			return $"{Common.Backoffice.Constants.UmbracoRelativeUrlStartPath}/{GetUmbracoApiDefaultRouteArea(controller)}/{controllerName}/{actionName}";

		return string.Empty;
	}

	private static string? GetUmbracoApiDefaultRouteArea(ControllerModel controller)
	{
		var pluginControllerAttribute = controller.ControllerType.GetCustomAttribute<PluginControllerAttribute>();
		return pluginControllerAttribute is null ? UmbracoApiDefaultRouteArea : pluginControllerAttribute.AreaName;
	}

	private static bool IsUmbracoNotAuthorizedApiController(ControllerModel controller)
	{
		return controller.ControllerType.Inherits<UmbracoApiController>();
	}

	private static bool IsUmbracoAuthorizedApiController(ControllerModel controller)
	{
		return controller.ControllerType.Inherits<UmbracoAuthorizedApiController>()
			   || controller.ControllerType.Inherits<UmbracoAuthorizedJsonController>();
	}
}