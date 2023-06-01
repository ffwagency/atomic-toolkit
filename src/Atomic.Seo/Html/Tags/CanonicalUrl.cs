using Atomic.Sео.Common.Extensions;
using Atomic.Sео.Html.Interfaces;
using Atomic.Seo.ModelsBuilder.Interfaces;

namespace Atomic.Sео.Html.Tags;

public class CanonicalUrl : ISeoHtmlTags
{
	public virtual string Get(ISeoBasePage seoPage, ISeoSettings seoSettings)
	{
		var url = seoPage.GetAbsoluteUrl();
		return $@"<link rel=""canonical"" href=""{url}"">{Environment.NewLine}";
	}
}