using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Atomic.Sео.DependencyInjection;

public class AtomicSeoComposer : IComposer
{
	public void Compose(IUmbracoBuilder builder)
		=> builder.AddAtomicSeo();
}