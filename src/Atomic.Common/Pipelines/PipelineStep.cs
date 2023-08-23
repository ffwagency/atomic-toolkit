namespace Atomic.Common.Pipelines;

public abstract class PipelineStep<TArgs> where TArgs : PipelineArgs
{
    protected virtual bool RunIfAborted { get; }

    protected PipelineStep<TArgs>? Successor { get; private set; }

    public void SetSuccesor(PipelineStep<TArgs> successor)
    {
        Successor = successor;
    }

    public abstract void Process(TArgs args);

    public virtual void HandleStep(TArgs args)
    {
        try
        {
            if (ShouldProcess(args))
                Process(args);
        }
        catch (Exception ex)
        {
            args.Abort($"Pipeline step failed: '{GetType().FullName}'.", ex);
        }

        Successor?.HandleStep(args);
    }

    private bool ShouldProcess(TArgs args)
    {
        return !args.Aborted || RunIfAborted;
    }
}