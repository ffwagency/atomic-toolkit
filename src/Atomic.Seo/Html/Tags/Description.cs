using Atomic.Common.Content.Extensions;
using Atomic.Seo.ModelsBuilder.Interfaces;
using Atomic.Sео.Html.Interfaces;
using StackExchange.Profiling.Internal;
using Umbraco.Extensions;
using Atomic.Sео.Html;
using Atomic.Sео.Html.Validators;

namespace Atomic.Sео.Html.Tags;

public class Description : ISeoHtmlTags
{
    public virtual string Get(ISeoBasePage seoPage, ISeoSettings seoSettings)
	{
		string? description = GetDescription(seoPage, seoSettings);

		if (description.HasNoDesctiption())
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

	private string? GetDescription(ISeoBasePage seoPage, ISeoSettings seoSettings)
    {
        string? description = seoPage.MetaDescription;

        if (description.HasNoDesctiption())
        {
            description = seoPage.GetValueWithFallback<string>(seoSettings.TextFallback);
        }

        return description;
    }
}