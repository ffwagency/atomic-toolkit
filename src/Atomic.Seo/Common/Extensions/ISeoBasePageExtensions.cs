using Atomic.Common.Content.Extensions;
using Atomic.Seo.ModelsBuilder.Interfaces;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Atomic.Sео.Common.Extensions
{
	public static class ISeoBasePageExtensions
	{
		public static string GetAbsoluteUrl(this ISeoBasePage seoPage, string? culture = null)
		{
			if (string.IsNullOrWhiteSpace(culture))
				culture = Thread.CurrentThread.CurrentCulture.Name;

			string url;

			if (!seoPage.ContentType.VariesByCulture())
			{
				var canonicalUrl = seoPage.CanonicalUrl;
				if (!string.IsNullOrWhiteSpace(canonicalUrl))
					url = canonicalUrl;
				else
					url = seoPage.Url(null, UrlMode.Absolute);
			}
			else
			{
				var canonicalUrl = seoPage.ValueFor(x => x.CanonicalUrl, culture);
				if (!string.IsNullOrWhiteSpace(canonicalUrl))
					url = canonicalUrl;
				else
					url = seoPage.Url(culture, UrlMode.Absolute);
			}

			return url;
		}

		public static string? GetShareImageAbsoluteUrl(this ISeoBasePage seoPage, ISeoSettings seoSettings)
		{
			var image = seoPage.ShareImage;

			if (image == null)
				image = seoPage.GetValueWithFallback<MediaWithCrops>(seoSettings.ImageFallback);
			if (image == null)
				image = seoSettings.ShareDefaultImage;
			if (image != null)
				return image.MediaUrl(null, UrlMode.Absolute);

			return string.Empty;
		}

		public static string GetShareTitle(this ISeoBasePage seoPage, ISeoSettings seoSettings)
		{
			var title = seoPage.ShareTitle;
			if (string.IsNullOrWhiteSpace(title))
				title = seoPage.GetValueWithFallback<string>(seoSettings.TitleFallback);
			if (string.IsNullOrWhiteSpace(title))
				title = seoPage.Name;
			return title;
		}

		public static string? GetShareText(this ISeoBasePage seoPage, ISeoSettings seoSettings)
		{
			var text = seoPage.ShareText;
			if (string.IsNullOrWhiteSpace(text))
				text = seoPage.GetValueWithFallback<string>(seoSettings.TextFallback);
			return text;
		}
	}
}