using AtomicStarterKit.Common.Configuration.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;
using Umbraco.Cms.Core.DependencyInjection;

namespace AtomicStarterKit.Common.DependencyInjection.Extensions;

public static class UmbracoBuilderExtensions
{
    public static IUmbracoBuilder AddAtomicStarterKitOptions<TOptions>(this IUmbracoBuilder builder, Action<OptionsBuilder<TOptions>>? configure = null)
        where TOptions : class
    {
        var atomicStarterKitAttribute = typeof(TOptions).GetCustomAttribute<AtomicStarterKitOptionsAttribute>();
        if (atomicStarterKitAttribute is null)
            throw new ArgumentException($"{typeof(TOptions)} do not have the {nameof(AtomicStarterKitOptionsAttribute)}.");

        var optionsBuilder = builder.Services.AddOptions<TOptions>()
            .Bind(builder.Config.GetSection(atomicStarterKitAttribute.ConfigurationKey),
                  o => o.BindNonPublicProperties = atomicStarterKitAttribute.BindNonPublicProperties)
            .ValidateDataAnnotations();

        configure?.Invoke(optionsBuilder);

        return builder;
    }
}