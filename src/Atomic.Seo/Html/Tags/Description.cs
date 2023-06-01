using Atomic.Common.Content.Extensions;
using Atomic.Seo.ModelsBuilder.Interfaces;
using Atomic.Sео.Html.Interfaces;
using StackExchange.Profiling.Internal;
using Umbraco.Extensions;

namespace Atomic.Sео.Html.Tags;

public class Description : ISeoHtmlTags
{
	public virtual string Get(ISeoBasePage seoPage, ISeoSettings seoSettings)
	{
		var description = seoPage.MetaDescription;
		if (string.IsNullOrWhiteSpace(description))
			description = seoPage.GetValueWithFallback<string>(seoSettings.TextFallback);

		if (string.IsNullOrWhiteSpace(description))
			return string.Empty;

		description = description.StripHtml()
								 .RemoveNewLines()
								 .Truncate(seoSettings.MetaDescriptionMaxLength != 0
										   ? seoSettings.MetaDescriptionMaxLength
										   : 150);

		return $@"<meta name=""description"" content=""{description}"">{Environment.NewLine}";
	}
}