using Atomic.Common.Configuration.Models;
using Atomic.Common.Content.Services;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Atomic.Common.DependencyInjection;

public class CommonComposer : IComposer
{
	public void Compose(IUmbracoBuilder builder)
	{
		builder.AddAtomicStarterKitOptions<AtomicStarterKitCommonSettings>();
		builder.Services.AddSingleton<MultisiteContentService>();
	}
}
