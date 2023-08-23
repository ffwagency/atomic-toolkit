using Microsoft.AspNetCore.Mvc;

namespace Atomic.Api.Response;

public sealed class AtomicResult : ObjectResult
{
    public AtomicResult(IAtomicResponseModel value)
        : base(value)
    {
        StatusCode = value.StatusCode;
    }
}