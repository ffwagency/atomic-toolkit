using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Atomic.Common.DependencyInjection;

public class AtomicCommonComposer : IComposer
{
	public void Compose(IUmbracoBuilder builder)
		=> builder.AddAtomicCommon();
}