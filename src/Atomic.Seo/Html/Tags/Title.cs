using Atomic.Common.Content.Extensions;
using Atomic.Seo.ModelsBuilder.Interfaces;
using Atomic.Sео.Html.Interfaces;

namespace Atomic.Sео.Html.Tags;

public class Title : ISeoHtmlTags
{
	public virtual string Get(ISeoBasePage seoPage, ISeoSettings seoSettings)
	{
		var title = seoPage.BrowserTitle;
		if (string.IsNullOrWhiteSpace(title))
			title = seoPage.GetValueWithFallback<string>(seoSettings.TitleFallback);
		if (string.IsNullOrWhiteSpace(title))
			title = seoPage.Name;

		return $"<title>{title}</title>{Environment.NewLine}";
	}
}