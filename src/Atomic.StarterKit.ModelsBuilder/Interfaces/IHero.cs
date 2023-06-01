using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface IHero : IPublishedElement
{
    Umbraco.Cms.Core.Models.MediaWithCrops BackgroundImage { get; }

    IEnumerable<Umbraco.Cms.Core.Models.Link> ButtonLink { get; }

    string SubTitle { get; }

    string Title { get; }
}