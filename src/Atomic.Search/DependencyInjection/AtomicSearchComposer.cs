using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Atomic.Search.DependencyInjection;

public class AtomicSearchComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
        => builder.AddAtomicSearch();
}