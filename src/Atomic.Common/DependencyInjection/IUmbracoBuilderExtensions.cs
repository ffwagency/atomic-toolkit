using Atomic.Common.Api.PreviewRoute;
using Atomic.Common.Api.Services;
using Atomic.Common.Backoffice.Services;
using Atomic.Common.Configuration.Attributes;
using Atomic.Common.Configuration.Models;
using Atomic.Common.Content.Services;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System.Reflection;
using Umbraco.Cms.Core.DependencyInjection;

namespace Atomic.Common.DependencyInjection;

public static class IUmbracoBuilderExtensions
{
	internal static IUmbracoBuilder AddAtomicCommon(this IUmbracoBuilder builder)
	{
		builder.AddAtomicOptions<AtomicCommonOptions>();

		builder.Services.AddSingleton<MultisiteContentService>();
		builder.Services.AddSingleton<ModelsBuilderService>();
		builder.Services.AddScoped<ApiLinkGenerator>();

		builder.Services.TryAddEnumerable(ServiceDescriptor.Transient<IApplicationModelProvider, PreviewRouteApplicationModelProvider>());

		return builder;
	}

	public static IUmbracoBuilder AddAtomicOptions<TOptions>(this IUmbracoBuilder builder, Action<OptionsBuilder<TOptions>>? configure = null)
		where TOptions : class
	{
		var atomicOptionsAttribute = typeof(TOptions).GetCustomAttribute<AtomicOptionsAttribute>();
		if (atomicOptionsAttribute is null)
			throw new ArgumentException($"{typeof(TOptions)} do not have the {nameof(AtomicOptionsAttribute)}.");

		var optionsBuilder = builder.Services.AddOptions<TOptions>()
			.Bind(builder.Config.GetSection(atomicOptionsAttribute.ConfigurationKey),
				  o => o.BindNonPublicProperties = atomicOptionsAttribute.BindNonPublicProperties)
			.ValidateDataAnnotations()
			.ValidateOnStart();

		configure?.Invoke(optionsBuilder);

		return builder;
	}
}