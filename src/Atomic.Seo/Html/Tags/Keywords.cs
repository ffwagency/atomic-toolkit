using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.Seo.Html.Tags;

public class Keywords : ISeoHtmlTags
{
	public virtual string Get(ISeoBasePage seoPage, SeoSettings seoSettings)
	{
		var keywords = seoPage.MetaKeywords?.ToArray() ?? Array.Empty<string>();
		if (keywords.Length == 0)
			return string.Empty;

		return $@"<meta name=""keywords"" content=""{string.Join(",", keywords)}"">{Environment.NewLine}";
	}
}
