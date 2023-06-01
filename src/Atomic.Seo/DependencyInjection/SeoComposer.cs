using Atomic.Sео.Html.Services;
using Atomic.Sео.SitemapXml.Services;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Atomic.Sео.DependencyInjection;

public class SeoComposer : IComposer
{
	public void Compose(IUmbracoBuilder builder)
	{
		builder.Services.AddSingleton<SeoHtmlTagsService>();
		builder.Services.AddSingleton<SitemapService>();

		builder.AddDefaultSeoHtmlTags();
	}
}