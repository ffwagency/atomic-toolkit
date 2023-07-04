using Umbraco.Cms.Web.Common.PublishedModels;
using Atomic.Common.Content;

namespace Atomic.Seo.Html.Tags;

public class Title : ISeoHtmlTags
{
	public virtual string Get(ISeoBasePage seoPage, SeoSettings seoSettings)
	{
		var title = seoPage.BrowserTitle;
		if (string.IsNullOrWhiteSpace(title))
			title = seoPage.GetValueWithFallback<string>(seoSettings.TitleFallback);
		if (string.IsNullOrWhiteSpace(title))
			title = seoPage.Name;

		return $"<title>{title}</title>{Environment.NewLine}";
	}
}