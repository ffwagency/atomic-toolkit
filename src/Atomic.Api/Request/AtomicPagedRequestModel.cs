using Umbraco.Extensions;

namespace Atomic.Api.Request;

public class AtomicPagedRequestModel : IAtomicRequestModel
{
    public AtomicPagedRequestModel()
    {
        PageSize = Common.Pagination.Constants.DefaultPageSize;
    }

    public int PageNumber { get; set; }

    public int PageSize { get; set; }

    public virtual ValidationResult IsValid(IServiceProvider requestServices)
    {
        var validationResult = new ValidationResult();

        if (PageNumber < 1)
            validationResult.Errors.Add($"'{nameof(PageNumber).ToFirstLower()}' must be >= 1.");
        if (PageSize < 1 || PageSize > Common.Pagination.Constants.MaxPageSize)
            validationResult.Errors.Add($"'{nameof(PageSize)}' must be >= 1 and <= {Common.Pagination.Constants.MaxPageSize}.");

        return validationResult;
    }
}