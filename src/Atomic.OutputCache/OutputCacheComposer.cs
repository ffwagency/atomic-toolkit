using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Atomic.OutputCache;

public class OutputCacheComposer : IComposer
{
	public void Compose(IUmbracoBuilder builder)
	{
		builder.ConfigureOutputCache();
	}
}