using AtomicStarterKit.Sео.DependencyInjection.Extensions;
using AtomicStarterKit.Sео.Html.Services;
using AtomicStarterKit.Sео.SitemapXml.Services;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace AtomicStarterKit.Sео.DependencyInjection.Composing;

public class AtomicStarterKitSeoComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.AddSingleton<SeoHtmlTagsService>();
        builder.Services.AddSingleton<SitemapService>();

        builder.AddDefaultSeoHtmlTags();
    }
}