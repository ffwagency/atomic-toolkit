using AtomicStarterKit.Sео.Services;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace AtomicStarterKit.Sео
{
    public class AtomicStarterKitSEOComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddSingleton<SeoService>();
        }
    }
}
