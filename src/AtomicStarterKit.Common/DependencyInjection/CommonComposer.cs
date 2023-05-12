using AtomicStarterKit.Common.Configuration.Models;
using AtomicStarterKit.Common.Content.Services;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace AtomicStarterKit.Common.DependencyInjection;

public class CommonComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.AddAtomicStarterKitOptions<AtomicStarterKitCommonSettings>();
        builder.Services.AddSingleton<MultisiteContentService>();
    }
}
