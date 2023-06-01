using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface ITimelineItem : IPublishedElement
{
    string Description { get; }

    Umbraco.Cms.Core.Models.MediaWithCrops Image { get; }

    string Title { get; }

    string YearsRange { get; }
}