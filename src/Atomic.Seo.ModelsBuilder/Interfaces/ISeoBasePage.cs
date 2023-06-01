using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.Seo.ModelsBuilder.Interfaces;

public interface ISeoBasePage : IPublishedContent
{
	string BrowserTitle { get; }

	string CanonicalUrl { get; }

	string ChangeFrequency { get; }

	string MetaDescription { get; }

	IEnumerable<string> MetaKeywords { get; }

	bool NoFollow { get; }

	bool NoIndex { get; }

	decimal Priority { get; }

	MediaWithCrops ShareImage { get; }

	string ShareText { get; }

	string ShareTitle { get; }
}