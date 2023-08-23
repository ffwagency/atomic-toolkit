using Atomic.Api.Response;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Atomic.Api.Request;

public sealed class ValidateAtomicRequestModelAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ActionArguments.TryGetValue("requestModel", out object? requestModel))
            return;

        if (requestModel is not IAtomicRequestModel atomicRequestModel)
            return;

        var validationResult = atomicRequestModel.IsValid(context.HttpContext.RequestServices);
        if (validationResult.IsValid)
            return;

        var model = new AtomicResponseModel<string>(HttpStatusCode.BadRequest,
            string.Empty,
            "Bad request. " + string.Join(" ", validationResult.Errors),
            null,
            DateTime.UtcNow);

        context.Result = new AtomicResult(model);
    }
}