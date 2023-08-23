namespace Atomic.Common.Pagination;

public class PagedResult<TResult>
{
    public PagedResult(int pageNumber,
        int pageSize,
        IEnumerable<TResult> results,
        long totalResults)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        Results = results;
        TotalResults = totalResults;
    }

    public IEnumerable<TResult> Results { get; }

    public int PageNumber { get; }

    public int PageSize { get; }

    public long TotalPages => TotalResults <= PageSize ? 1 : TotalResults / PageSize;

    public int FirstPageNumber => 1;

    public long TotalResults { get; }

    public PagedResult<TConvertedResult> Convert<TConvertedResult>(Func<IEnumerable<TResult>, IEnumerable<TConvertedResult>> func)
    {
        var converteResults = func.Invoke(Results);
        return new PagedResult<TConvertedResult>(PageNumber, PageSize, converteResults, TotalResults);
    }

    public static PagedResult<TResult> Empty(int pageNumber, int pageSize) => new(pageNumber, pageSize, Enumerable.Empty<TResult>(), 0);
}