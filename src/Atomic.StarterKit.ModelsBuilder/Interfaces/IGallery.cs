using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface IGallery : IPublishedElement
{
    IEnumerable<Umbraco.Cms.Core.Models.MediaWithCrops> MediaItems { get; }

    string PreTitle { get; }

    string Title { get; }
}