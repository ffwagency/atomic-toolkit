using Atomic.Seo.ModelsBuilder.Interfaces;

namespace Atomic.Sео.Html.Interfaces;

public interface ISeoHtmlTags
{
	string Get(ISeoBasePage page, ISeoSettings seoSettings);
}