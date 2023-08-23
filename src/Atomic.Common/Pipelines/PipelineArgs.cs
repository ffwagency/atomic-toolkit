using Atomic.Common.ErrorHandling;

namespace Atomic.Common.Pipelines;

public abstract class PipelineArgs
{
    public bool Aborted { get; private set; }
    public List<Exception> Exceptions  { get; } = new List<Exception>();

    public void Abort(string message, Exception exception)
    {
        Aborted = true;
        exception.AddImportantInfo(message);
        Exceptions.Add(exception);
    }
}