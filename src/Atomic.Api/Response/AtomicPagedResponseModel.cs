using System.Net;

namespace Atomic.Api.Response;

public class AtomicPagedResponseModel<T> : IAtomicResponseModel
{
    public AtomicPagedResponseModel(HttpStatusCode statusCode,
        Pagination pagination,
        IEnumerable<T>? data,
        string? errorMessage,
        string[]? errorIds,
        DateTime timestampUtc)
    {
        StatusCode = (int)statusCode;
        Pagination = pagination;
        Data = data?.ToArray();
        ErrorMessage = errorMessage;
        ErrorIds = errorIds;
        TimestampUtc = timestampUtc;
    }

    public int StatusCode { get; }

    public Pagination Pagination { get; set; }

    public T[]? Data { get; }

    public string? ErrorMessage { get; }

    public string[]? ErrorIds { get; }

    public DateTime TimestampUtc { get; }
}