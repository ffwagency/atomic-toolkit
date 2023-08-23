using Umbraco.Cms.Core.Composing;

namespace Atomic.Common.Pipelines;

public class Pipeline<TArgs>
    : BuilderCollectionBase<PipelineStep<TArgs>>
    where TArgs : PipelineArgs
{
    public Pipeline(Func<IEnumerable<PipelineStep<TArgs>>> items)
        : base(items)
    { }

    public void Run(TArgs args, bool throwExceptionIfAborted = true)
    {
        var steps = this.ToArray();

        SetSuccessors(steps);

        steps[0].HandleStep(args);

        if (args.Aborted && throwExceptionIfAborted)
            PipelineExcepton.Throw($"Pipeline errors occurred: {GetType().FullName}", args.Exceptions.ToArray());
    }

    private static void SetSuccessors(PipelineStep<TArgs>[] steps)
    {
        for (int i = 0; i < steps.Length; i++)
        {
            if (i + 1 < steps.Length)
                steps[i].SetSuccesor(steps[i + 1]);
        }
    }
}