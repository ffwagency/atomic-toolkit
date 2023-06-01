using Atomic.Seo.ModelsBuilder.Interfaces;
using Atomic.Sео.Html.Interfaces;

namespace Atomic.Sео.Html.Tags;

public class Robots : ISeoHtmlTags
{
	public virtual string Get(ISeoBasePage seoPage, ISeoSettings seoSettings)
	{
		var index = "index";
		var follow = "follow";

		if (seoPage.NoIndex || seoPage.Name == "404" || seoPage.Name == "500")
			index = $"no{index}";
		if (seoPage.NoFollow || seoPage.Name == "404" || seoPage.Name == "500")
			follow = $"no{follow}";

		return $@"<meta name=""robots"" content=""{index}, {follow}"">{Environment.NewLine}";
	}
}