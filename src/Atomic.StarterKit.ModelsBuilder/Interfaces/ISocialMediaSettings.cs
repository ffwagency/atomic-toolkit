using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface ISocialMediaSettings : IPublishedContent
{
    string FacebookProfileLink { get; }

    string InstagramProfileLink { get; }

    string PinterestProfileLink { get; }

    string TwitterProfileLink { get; }

}