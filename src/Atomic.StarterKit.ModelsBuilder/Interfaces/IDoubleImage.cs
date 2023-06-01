using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface IDoubleImage : IPublishedElement
{
    string LeftImageCaption { get; }

    string LeftImageDescription { get; }

    Umbraco.Cms.Core.Models.MediaWithCrops LeftImageSource { get; }

    string RightImageCaption { get; }

    string RightImageDescription { get; }

    Umbraco.Cms.Core.Models.MediaWithCrops RightImageSource { get; }
}