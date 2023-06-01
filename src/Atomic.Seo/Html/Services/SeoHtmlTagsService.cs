using Microsoft.AspNetCore.Html;
using System.Text;
using Atomic.Sео.Html.Collections;
using Atomic.Seo.ModelsBuilder.Interfaces;

namespace Atomic.Sео.Html.Services;

public class SeoHtmlTagsService
{
	private readonly SeoHtmlTagsCollection _seoHtmlTagsCollection;

	public SeoHtmlTagsService(SeoHtmlTagsCollection seoHtmlTagsCollection)
	{
		_seoHtmlTagsCollection = seoHtmlTagsCollection;
	}

	public HtmlString GetHtmlTags(ISeoBasePage seoPage, ISeoSettings seoSettings)
	{
		var html = new StringBuilder();

		foreach (var seoHtmlTags in _seoHtmlTagsCollection)
			html.AppendLine(seoHtmlTags.Get(seoPage, seoSettings));

		return new HtmlString(html.ToString());
	}
}