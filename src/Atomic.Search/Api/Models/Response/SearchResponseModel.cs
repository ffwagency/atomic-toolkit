using Atomic.Common.Pagination;

namespace Atomic.Search.Api.Models.Response;

public class SearchResponseModel : PagedResult<SearchApiResult>
{
    public SearchResponseModel(int pageNumber,
        int pageSize,
        IEnumerable<SearchApiResult> results,
        long totalResults)
        : base(pageNumber, pageSize, results, totalResults)
    { }

    new public static SearchResponseModel Empty(int pageNumber, int pageSize) => new(pageNumber, pageSize, Enumerable.Empty<SearchApiResult>(), 0);
}