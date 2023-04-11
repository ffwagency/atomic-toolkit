using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace AtomicStarterKit.Sео
{
    public class SeoBackofficeManagableSettings : PublishedContentModel
    {
        public const string ModelTypeAlias = "seoSettings";

        public SeoBackofficeManagableSettings(IPublishedContent settings, IPublishedValueFallback publishedValueFallback) : base(settings, publishedValueFallback)
        { }

        public virtual MediaWithCrops SocialMediaShareDefaultImage => this.Value<MediaWithCrops>("socialMediaShareDefaultImage");
        public virtual string RobotsTxt => this.Value<string>("robotsTxt");
    }
}