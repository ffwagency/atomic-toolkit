namespace Atomic.Common.Pipelines;

public class PipelineExcepton : Exception
{
    public Exception[] InnerExceptions { get; } = Array.Empty<Exception>();

    public PipelineExcepton(string? message, params Exception[] innerExceptions) : base(message)
    {
        InnerExceptions = innerExceptions;
    }

    private PipelineExcepton() : base()
    { }

    private PipelineExcepton(string? message) : base(message)
    { }

    private PipelineExcepton(string? message, Exception? innerException) : base(message, innerException)
    { }

    public static void Throw(string? message, params Exception[] innerExceptions)
    {
        if (innerExceptions.Any())
            throw new PipelineExcepton(message, innerExceptions);
    }
}