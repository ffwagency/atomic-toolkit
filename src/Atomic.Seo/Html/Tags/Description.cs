using Umbraco.Cms.Web.Common.PublishedModels;
using StackExchange.Profiling.Internal;
using Umbraco.Extensions;
using Atomic.Common.Content;

namespace Atomic.Sео.Html.Tags;

public class Description : ISeoHtmlTags
{
    public virtual string Get(ISeoBasePage seoPage, SeoSettings seoSettings)
	{
		string? description = GetDescription(seoPage, seoSettings);

		if (!description.HasDescription())
		{
			return string.Empty;
		}

		description = description!.StripHtml()
								 .RemoveNewLines()
								 .Truncate(seoSettings.MetaDescriptionMaxLength.HasMetaDescriptionMaxLengthDefined()
										   ? seoSettings.MetaDescriptionMaxLength
										   : Constants.MetaDescriptionDefaultMaxLength);

		return $@"<meta name=""description"" content=""{description}"">{Environment.NewLine}";
	}

	private string? GetDescription(ISeoBasePage seoPage, SeoSettings seoSettings)
    {
        string? description = seoPage.MetaDescription;

        if (!description.HasDescription())
        {
            description = seoPage.GetValueWithFallback<string>(seoSettings.TextFallback);
        }

        return description;
    }
}