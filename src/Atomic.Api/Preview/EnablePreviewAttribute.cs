using Atomic.Api.Controllers;
using Atomic.Common.Backoffice;
using Microsoft.AspNetCore.Mvc.Filters;
using Umbraco.Cms.Infrastructure.PublishedCache;

namespace Atomic.Api.Preview
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public sealed class EnablePreviewAttribute : Attribute, IActionFilter
	{
		private IDisposable? _forcedPreview;
		private PublishedSnapshot? _publishedSnapshot;

		public void OnActionExecuting(ActionExecutingContext context)
		{
			var controller = context.Controller;

			NotSupportedPreviewException.ThrowIfDoesNotSupportPreview(controller.GetType());

			if (!context.HttpContext.Request.IsPreviewRequest())
				return;

			EnablePreview((IAtomicApiController)controller);
		}

		public void OnActionExecuted(ActionExecutedContext context)
		{
			DisablePreview();
		}

		private void EnablePreview(IAtomicApiController controller)
		{
			var umbracoContext = controller.UmbracoContext;

			if (umbracoContext.InPreviewMode)
				return;

			_forcedPreview = umbracoContext.ForcedPreview(true);
			_publishedSnapshot = umbracoContext.PublishedSnapshot as PublishedSnapshot;
			_publishedSnapshot?.Resync(); // ForcedPreview(true) doesn't work by its own. this is needed as well (probably Umbraco Bug)
		}

		private void DisablePreview()
		{
			_forcedPreview?.Dispose();
			_publishedSnapshot?.Resync(); // ForcedPreview(true) doesn't work by its own. this is needed as well (probably Umbraco Bug)
		}
	}
}