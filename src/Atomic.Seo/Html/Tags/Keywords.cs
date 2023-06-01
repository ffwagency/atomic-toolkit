using Atomic.Seo.ModelsBuilder.Interfaces;
using Atomic.Sео.Html.Interfaces;

namespace Atomic.Sео.Html.Tags;

public class Keywords : ISeoHtmlTags
{
	public virtual string Get(ISeoBasePage seoPage, ISeoSettings seoSettings)
	{
		var keywords = seoPage.MetaKeywords?.ToArray() ?? Array.Empty<string>();
		if (keywords.Length == 0)
			return string.Empty;

		return $@"<meta name=""keywords"" content=""{string.Join(",", keywords)}"">{Environment.NewLine}";
	}
}
