using Atomic.Api.Request;
using Atomic.Search.Fields;
using Atomic.Search.Fields.Base;
using Atomic.Search.Fields.Exceptions;
using Atomic.Search.Models;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Extensions;

namespace Atomic.Search.Api.Models.Request;

public class SearchRequestModel : AtomicPagedRequestModel
{
    public string? Term { get; set; }

    public Dictionary<string, string?> Filter { get; set; } = new Dictionary<string, string?>();

    public string? SortBy { get; set; }

    public SortOrder SortOrder { get; set; } = SortOrder.Asc;

    public override ValidationResult IsValid(IServiceProvider requestServices)
    {
        var validationResult = base.IsValid(requestServices);

        if (IsEmpty)
            validationResult.Errors.Add("Search query is empty.");

        var searchFields = requestServices.GetRequiredService<SearchFieldsCollection>();

        var invalidQueryStringParams = FindInvalidQueryStringParams(searchFields);
        if (invalidQueryStringParams.Any())
            validationResult.Errors.Add($"Invalid query string params: '{string.Join(',', invalidQueryStringParams)}'.");

        if (!IsSortBySortable(searchFields))
            validationResult.Errors.Add($"Invalid {nameof(SortBy).ToFirstLower()} param: '{SortBy}'. This search field is not sortable.");

        return validationResult;
    }

    private List<string> FindInvalidQueryStringParams(SearchFieldsCollection searchFields)
    {
        var invalidQueryStringParams = new List<string>();

        foreach (var key in GetQueryStringParamsForCheck())
        {
            try
            {
                searchFields.GetRequiredSearchField(key);
            }
            catch
            {
                invalidQueryStringParams.Add(key);
            }
        }

        return invalidQueryStringParams;
    }

    private bool IsSortBySortable(SearchFieldsCollection searchFields)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(SortBy))
                return true;

            InvalidSortableFieldException.ThrowIfNotOfType<ISortable>(searchFields.GetRequiredSearchField(SortBy));
        }
        catch
        {
            return false;
        }

        return false;
    }

    private List<string> GetQueryStringParamsForCheck()
    {
        var queryStringParamsToCheck = Filter.Keys.ToList();
        if (!string.IsNullOrWhiteSpace(SortBy))
            queryStringParamsToCheck.Add(SortBy);
        return queryStringParamsToCheck;
    }

    private bool IsEmpty => string.IsNullOrWhiteSpace(Term) && Filter?.Count == 0;
}