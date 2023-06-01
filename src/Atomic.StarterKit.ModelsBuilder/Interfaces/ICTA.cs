using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface ICTA : IPublishedElement
{
    IEnumerable<Umbraco.Cms.Core.Models.Link> CTalink { get; }

    string Description { get; }

    Umbraco.Cms.Core.Models.MediaWithCrops Image { get; }

    string Title { get; }
}