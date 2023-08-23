using Atomic.Api.Response;
using Atomic.Common.ErrorHandling;
using Atomic.Common.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;

namespace Atomic.Api.Controllers;

public static class ControllerBaseExtensions
{
    public static AtomicResult AtomicSuccessResponse<T>(this ControllerBase controller, T? data)
    {
        if (data is null)
            return controller.AtomicErrorResponse(HttpStatusCode.NotFound, ErrorMessages.NotFoundError);

        var model = new AtomicResponseModel<T>(
            HttpStatusCode.OK,
            data,
            null,
            null,
            DateTime.UtcNow);

        return new AtomicResult(model);
    }

    public static AtomicResult AtomicSuccessResponse<T>(this ControllerBase controller, PagedResult<T> pagedResult)
    {
        if (pagedResult.TotalResults == 0)
            return controller.AtomicErrorResponse(HttpStatusCode.NotFound, ErrorMessages.NotFoundError);

        var previosPageUrl = GetPreviousPageUrl(controller, pagedResult);
        var currentPageUrl = GetCurrentPageUrl(controller);
        var nextPageUrl = GetNextPageUrl(controller, pagedResult);

        var model = new AtomicPagedResponseModel<T>(
            HttpStatusCode.OK,
            new Pagination(previosPageUrl, currentPageUrl, nextPageUrl, pagedResult.PageNumber, pagedResult.PageSize, pagedResult.TotalPages, pagedResult.TotalResults),
            pagedResult.Results,
            null,
            null,
            DateTime.UtcNow);

        return new AtomicResult(model);
    }

    public static AtomicResult AtomicErrorResponse(this ControllerBase controller,
        HttpStatusCode statusCode,
        string errorMessage,
        IEnumerable<string>? errorIds = null)
    {
        var model = new AtomicResponseModel<string>(
            statusCode,
            null,
            errorMessage,
            errorIds?.ToArray(),
            DateTime.UtcNow);

        return new AtomicResult(model);
    }

    private static string? GetPreviousPageUrl<T>(ControllerBase controller, PagedResult<T> pagedResult)
    {
        if (pagedResult.PageNumber > pagedResult.FirstPageNumber)
        {
            var baseUrl = controller.Request.GetEncodedUrl();
            if (baseUrl.Contains('?'))
                baseUrl = baseUrl.Substring(0, baseUrl.IndexOf("?"));

            var query = QueryHelpers.ParseQuery(controller.Request.QueryString.Value);
            query[Constants.Pagination.PageSizeQueryStringParam] = pagedResult.PageSize.ToString();
            query[Constants.Pagination.PageNumberQueryStringParam] = (pagedResult.PageNumber - 1).ToString();
            var queryString = QueryString.Create(query);

            return $"{baseUrl}{queryString}";
        }

        return null;
    }

    private static string GetCurrentPageUrl(ControllerBase controller)
    {
        return controller.Request.GetEncodedUrl();
    }

    private static string? GetNextPageUrl<T>(ControllerBase controller, PagedResult<T> pagedResult)
    {
        if (pagedResult.PageNumber != pagedResult.TotalPages)
        {
            var baseUrl = controller.Request.GetEncodedUrl();
            if (baseUrl.Contains('?'))
                baseUrl = baseUrl.Substring(0, baseUrl.IndexOf("?"));

            var query = QueryHelpers.ParseQuery(controller.Request.QueryString.Value);
            query[Constants.Pagination.PageSizeQueryStringParam] = pagedResult.PageSize.ToString();
            query[Constants.Pagination.PageNumberQueryStringParam] = (pagedResult.PageNumber + 1).ToString();
            var queryString = QueryString.Create(query);

            return $"{baseUrl}{queryString}";
        }

        return null;
    }
}