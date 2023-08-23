using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;
using Umbraco.Cms.Core.DependencyInjection;

namespace Atomic.Common.Configuration;

public static class IUmbracoBuilderExtensions
{
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