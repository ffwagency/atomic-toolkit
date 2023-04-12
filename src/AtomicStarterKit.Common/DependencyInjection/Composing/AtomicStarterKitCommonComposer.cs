using AtomicStarterKit.Common.Configuration.Models;
using AtomicStarterKit.Common.Content.Services;
using AtomicStarterKit.Common.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace AtomicStarterKit.Common.DependencyInjection.Composing;

public class AtomicStarterKitCommonComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.AddAtomicStarterKitOptions<AtomicStarterKitCommonSettings>();
        builder.Services.AddSingleton<MultisiteContentService>();
    }
}
