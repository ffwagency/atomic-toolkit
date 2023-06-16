using Atomic.Common.Backoffice;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Atomic.Api.Preview
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public sealed class EnablePreviewAttribute : Attribute, IActionFilter
	{
		private IDisposable? _forcedPreview;

		public void OnActionExecuting(ActionExecutingContext context)
		{
			var controller = context.Controller;

			NotSupportedPreviewException.ThrowIfDoesNotSupportPreview(controller?.GetType());

			if (context.HttpContext.InPreviewMode())
				_forcedPreview = ((IAtomicUmbracoApiController)context.Controller).UmbracoContext.ForcedPreview(true);
		}

		public void OnActionExecuted(ActionExecutedContext context)
		{
			_forcedPreview?.Dispose();
		}
	}
}