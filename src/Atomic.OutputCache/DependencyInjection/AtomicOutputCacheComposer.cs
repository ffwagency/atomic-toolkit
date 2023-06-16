using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Atomic.OutputCache.DependencyInjection;

public class AtomicOutputCacheComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
        => builder.AddAtomicOutputCache();
}