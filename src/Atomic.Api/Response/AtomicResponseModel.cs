using System.Net;

namespace Atomic.Api.Response;

public class AtomicResponseModel<T> : IAtomicResponseModel
{
    public AtomicResponseModel(HttpStatusCode statusCode,
        T? data,
        string? errorMessage,
        string[]? errorIds,
        DateTime timestampUtc)
    {
        StatusCode = (int)statusCode;
        Data = data;
        ErrorMessage = errorMessage;
        ErrorIds = errorIds;
        TimestampUtc = timestampUtc;
    }

    public int StatusCode { get; }

    public T? Data { get; }

    public string? ErrorMessage { get; }

    public string[]? ErrorIds { get; }

    public DateTime TimestampUtc { get; }
}