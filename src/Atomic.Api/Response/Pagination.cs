namespace Atomic.Api.Response;

public record Pagination(string? PreviousPageUrl,
    string CurrentPageUrl,
    string? NextPageUrl,
    int PageNumber,
    int PageSize,
    long TotalPages,
    long TotalResults);