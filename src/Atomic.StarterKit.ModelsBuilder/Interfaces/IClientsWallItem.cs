using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface IClientsWallItem : IPublishedElement
{
    IEnumerable<Umbraco.Cms.Core.Models.Link> Link { get; }

    Umbraco.Cms.Core.Models.MediaWithCrops Logo { get; }
}