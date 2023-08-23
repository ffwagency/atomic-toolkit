namespace Atomic.Search.Querying;

public class SearchQuery
{
    public SearchQuery(int pageNumber,
        int pageSize,
        TextQuery? textQuery = null,
        FilterQuery? filterQuery = null,
        SortQuery? sortQuery = null)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        TextQuery = textQuery;
        FilterQuery = filterQuery;
        SortQuery = sortQuery;
    }

    public int PageNumber { get; }
    public int PageSize { get; }

    public TextQuery? TextQuery { get; }

    public FilterQuery? FilterQuery { get; }

    public SortQuery? SortQuery { get; }
}