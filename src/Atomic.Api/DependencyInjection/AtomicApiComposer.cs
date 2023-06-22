using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Atomic.Api.DependencyInjection;

public class AtomicApiComposer : IComposer
{
	public void Compose(IUmbracoBuilder builder)
		=> builder.AddAtomicApi();
}