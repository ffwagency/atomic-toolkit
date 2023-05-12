using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace AtomicStarterKit.OutputCache;

public class OutputCacheComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.ConfigureOutputCache();
    }
}