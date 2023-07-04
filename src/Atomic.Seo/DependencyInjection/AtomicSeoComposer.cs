using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Atomic.Seo.DependencyInjection;

public class AtomicSeoComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
        => builder.AddAtomicSeo();
}