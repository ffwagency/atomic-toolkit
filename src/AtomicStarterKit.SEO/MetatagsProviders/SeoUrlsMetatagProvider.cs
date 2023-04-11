using System.Text;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;
using Umbraco.Cms.Core.Services;
using AtomicStarterKit.Common.Extensions;
using AtomicStarterKit.Sео.Interfaces;

namespace AtomicStarterKit.Sео.MetatagsProviders
{
    public class SeoUrlsMetatagProvider : ISeoMetatagsProvider
    {
        private string _defaultLanguage;
        private string DefaultLanguage
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_defaultLanguage))
                    _defaultLanguage = _localizationService.GetDefaultLanguageIsoCode();
                return _defaultLanguage;
            }
        }
        private readonly ILocalizationService _localizationService;

        public SeoUrlsMetatagProvider(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }
        public string GetHtml(IPublishedContent page, SeoBackofficeManagableSettings seoSettings)
        {
            var availableLangs = page.Cultures.Keys.ToArray();
            var currentLang = Thread.CurrentThread.CurrentCulture.Name;

            var sb = new StringBuilder();

            var currentLangUrl = page.Url(currentLang, UrlMode.Absolute);
            if (currentLangUrl == "#")
                currentLangUrl = page.Url(null, UrlMode.Absolute);
            sb.Append($@"<link rel=""canonical"" href=""{currentLangUrl}"" />{Environment.NewLine}");

            if (availableLangs.Length > 1)
            {
                foreach (var lang in availableLangs.Select(x => x.CultureRegionToUpper()))
                {
                    var langUrl = page.Url(lang, UrlMode.Absolute);
                    if (langUrl == "#")
                        langUrl = page.Url(null, UrlMode.Absolute);

                    sb.Append(@"<link rel=""alternate"" href=""").Append(langUrl).Append(@""" hreflang=""").Append(lang).AppendLine(@""">");

                    if (lang.Equals(DefaultLanguage, StringComparison.OrdinalIgnoreCase))
                        sb.Append(@"<link rel=""alternate"" href=""").Append(langUrl).AppendLine(@""" hreflang=""x-default"">");
                }

            }

            return sb.ToString();
        }
    }
}