using Atomic.Api.Request;
using Atomic.Search.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Primitives;

namespace Atomic.Search.Api.Models.Request;

public class SearchRequestModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        var model = new SearchRequestModel();
        var queryString = bindingContext.HttpContext.Request.Query;

        BindPageNumber(model, queryString);
        BindPageSize(model, queryString);
        BindTerm(model, queryString);
        BindSort(model, queryString);
        BindFitler(model, queryString);

        bindingContext.Result = ModelBindingResult.Success(model);
        return Task.CompletedTask;
    }

    private static void BindFitler(SearchRequestModel model, IQueryCollection queryString)
    {
        foreach (var queryParam in queryString)
        {
            if (!IsFilterQueryParam(queryParam))
                continue;

            model.Filter[queryParam.Key] = queryParam.Value;
        }
    }

    private static bool IsFilterQueryParam(KeyValuePair<string, StringValues> queryParam)
    {
        return !string.Equals(queryParam.Key, nameof(SearchRequestModel.Term), StringComparison.OrdinalIgnoreCase)
            && !string.Equals(queryParam.Key, nameof(SearchRequestModel.SortBy), StringComparison.OrdinalIgnoreCase)
            && !string.Equals(queryParam.Key, nameof(SearchRequestModel.SortOrder), StringComparison.OrdinalIgnoreCase)
            && !string.Equals(queryParam.Key, nameof(AtomicPagedRequestModel.PageNumber), StringComparison.OrdinalIgnoreCase)
            && !string.Equals(queryParam.Key, nameof(AtomicPagedRequestModel.PageSize), StringComparison.OrdinalIgnoreCase);
    }

    private static void BindTerm(SearchRequestModel model, IQueryCollection queryString)
    {
        if (queryString.TryGetValue(nameof(SearchRequestModel.Term), out StringValues termValue))
            model.Term = termValue;
    }

    private static void BindPageNumber(SearchRequestModel model, IQueryCollection queryString)
    {
        if (queryString.TryGetValue(nameof(AtomicPagedRequestModel.PageNumber), out StringValues pageNumberString)
            && int.TryParse(pageNumberString, out int pageNumber))
            model.PageNumber = pageNumber;
    }

    private static void BindPageSize(SearchRequestModel model, IQueryCollection queryString)
    {
        if (queryString.TryGetValue(nameof(AtomicPagedRequestModel.PageSize), out StringValues pageSizeString)
            && int.TryParse(pageSizeString, out int pageSize))
            model.PageSize = pageSize;
    }

    private static void BindSort(SearchRequestModel model, IQueryCollection queryString)
    {
        if (queryString.TryGetValue(nameof(SearchRequestModel.SortBy), out StringValues sortByValue))
            model.SortBy = sortByValue;

        if (queryString.TryGetValue(nameof(SearchRequestModel.SortOrder), out StringValues sortOrderValue)
            && Enum.TryParse(sortOrderValue, out SortOrder sortOrder))
            model.SortOrder = sortOrder;
    }
}