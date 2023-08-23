namespace Atomic.Api.Request;

public interface IAtomicRequestModel
{
    public ValidationResult IsValid(IServiceProvider requestServices);
}