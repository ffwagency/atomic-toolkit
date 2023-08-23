using Atomic.Api.Auth;
using Atomic.Api.Response;
using Atomic.Common.ErrorHandling;
using Atomic.Common.Pipelines;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;
using System.Text;
using Umbraco.Extensions;

namespace Atomic.Api.ErrorHandling;

public class AtomicExceptionFilterAttribute : TypeFilterAttribute
{
    public AtomicExceptionFilterAttribute() : base(typeof(AtomicApiExceptionFilter))
    { }

    private class AtomicApiExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<AtomicApiExceptionFilter> _logger;
        private readonly AtomicApiOptions _options;

        public AtomicApiExceptionFilter(ILogger<AtomicApiExceptionFilter> logger,
            IOptions<AtomicApiOptions> options)
        {
            _logger = logger;
            _options = options.Value;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled)
                return;

            var errorIds = HandleException(context);

            context.Result = BuildResult(context, errorIds);

            context.ExceptionHandled = true;
        }

        private ObjectResult BuildResult(ExceptionContext context, IEnumerable<string> errorIds)
        {
            var responseModel = new AtomicResponseModel<object>(HttpStatusCode.InternalServerError,
                                        GetModel(context),
                                        ErrorMessages.InternalServerError,
                                        errorIds.ToArray(),
                                        DateTime.UtcNow);

            return new ObjectResult(responseModel)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }

        private IEnumerable<string> HandleException(ExceptionContext context)
        {
            var errorIds = new List<string>();

            switch (context.Exception)
            {
                case PipelineExcepton pipelineException:
                    foreach (var innerException in pipelineException.InnerExceptions)
                        errorIds.Add(_logger.LogErrorWithUniqueID(innerException));
                    break;
                default:
                    errorIds.Add(_logger.LogErrorWithUniqueID(context.Exception));
                    break;
            }

            return errorIds;
        }

        private object? GetModel(ExceptionContext context)
        {
            if (!IsDebuggingEnabled(context))
                return null;

            var debuggingInfo = new DebuggingInfo(context.Exception.MessageWithImportantInfo());

            switch (context.Exception)
            {
                case PipelineExcepton pipelineException:
                    foreach (var innerException in pipelineException.InnerExceptions)
                        AddErrorToDebuggingInfo(debuggingInfo, innerException);
                    break;
                default:
                    AddErrorToDebuggingInfo(debuggingInfo, context.Exception);
                    break;
            }

            return debuggingInfo;
        }

        private static void AddErrorToDebuggingInfo(DebuggingInfo debuggingInfo, Exception innerException)
        {
            debuggingInfo.Errors.Add(new Error(GetFullExceptionMessage(innerException),
                                               GetInnermostStackTrace(innerException)));
        }

        private bool IsDebuggingEnabled(ExceptionContext context)
        {
            var token = context.HttpContext.Request.Headers.GetValueAsString(AtomicAuthPolicy.EnableApiDebuggingTokenName);

            if (string.IsNullOrWhiteSpace(token))
                return false;

            return _options.EnableApiDebuggingToken.InvariantEquals(token);
        }

        private static string GetFullExceptionMessage(Exception? ex)
        {
            var sb = new StringBuilder();

            while (ex != null)
            {
                sb.Append(ex.MessageWithImportantInfo()).Append(" ");
                ex = ex.InnerException;
            }

            return sb.ToString().Trim(' ');
        }

        private static string? GetInnermostStackTrace(Exception? ex)
        {
            while (ex?.InnerException != null)
                ex = ex.InnerException;

            return ex?.StackTrace;
        }
    }
}