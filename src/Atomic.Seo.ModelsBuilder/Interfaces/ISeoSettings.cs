using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.Seo.ModelsBuilder.Interfaces;

public interface ISeoSettings : IPublishedContent
{
	IEnumerable<string> ImageFallback { get; }

	int MetaDescriptionMaxLength { get; }

	string RobotsTxt { get; }

	MediaWithCrops ShareDefaultImage { get; }

	int ShareTextMaxLength { get; }

	int SitemapCacheDuration { get; }

	IEnumerable<string> TextFallback { get; }

	IEnumerable<string> TitleFallback { get; }

	bool TurnOffSeo { get; }

	bool TurnOffSitemapCache { get; }
}