using Atomic.Common.Backoffice.Services;
using Atomic.Common.Configuration.Models;
using Atomic.Common.Content.Services;
using Atomic.Common.ModelsBuilder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Infrastructure.ModelsBuilder.Building;

namespace Atomic.Common.DependencyInjection;

public class CommonComposer : IComposer
{
	public void Compose(IUmbracoBuilder builder)
	{
		builder.AddAtomicStarterKitOptions<AtomicStarterKitCommonSettings>();
		builder.Services.AddSingleton<MultisiteContentService>();
		builder.Services.AddSingleton<ModelsBuilderService>();
		builder.Services.Replace(ServiceDescriptor.Singleton<IModelsGenerator, AtomicModelsGenerator>());
	}
}