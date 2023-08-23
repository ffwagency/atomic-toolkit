using Atomic.Common.Configuration;
using Atomic.Common.Content;
using Atomic.Common.ModelsBuilder;
using Atomic.Common.Multilanguage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Infrastructure.ModelsBuilder.Building;

namespace Atomic.Common.DependencyInjection;

public static class IUmbracoBuilderExtensions
{
	internal static IUmbracoBuilder AddAtomicCommon(this IUmbracoBuilder builder)
	{
		builder.AddAtomicOptions<AtomicCommonOptions>();

		builder.Services.AddSingleton<MultisiteContentService>();
		builder.Services.AddTransient<CulturesService>();
		builder.Services.Replace(ServiceDescriptor.Singleton<IModelsGenerator, AtomicModelsGenerator>());

		return builder;
	}
}