using AtomicStarterKit.Common.Services;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace AtomicStarterKit.Common
{
    public class AtomicStarterKitCommonComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddSingleton<ContentTreeNavigator>();
        }
    }
}
