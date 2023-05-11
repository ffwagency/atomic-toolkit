using AtomicStarterKit.Umbraco.OutputCache;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace AtomicStarterKit.Umbraco;

public class AtomicStarterKitComposer : IComposer
{
	public void Compose(IUmbracoBuilder builder)
	{
		builder.ConfigureOutputCache();
	}
}