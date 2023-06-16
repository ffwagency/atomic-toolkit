using System.Text;
using Umbraco.Extensions;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.Sео.Html.Tags;

public class AlternateUrls : ISeoHtmlTags
{
	private readonly ILocalizationService _localizationService;

	public AlternateUrls(ILocalizationService localizationService)
	{
		_localizationService = localizationService;
	}

	public virtual string Get(ISeoBasePage seoPage, SeoSettings seoSettings)
	{
		var allCultures = seoPage.Cultures.Keys.ToArray();

		if (allCultures.Length <= 1)
			return string.Empty;

		var defaultCulture = _localizationService.GetDefaultLanguageIsoCode();
		var html = new StringBuilder();

		foreach (var culture in allCultures)
		{
			var url = seoPage.GetAbsoluteUrl(culture);

			html.AppendLine($@"<link rel=""alternate"" href=""{url}"" hreflang=""{culture}"">");

			if (culture.InvariantEquals(defaultCulture))
				html.AppendLine($@"<link rel=""alternate"" href=""{url}"" hreflang=""x-default"">");
		}

		return html.ToString();
	}
}