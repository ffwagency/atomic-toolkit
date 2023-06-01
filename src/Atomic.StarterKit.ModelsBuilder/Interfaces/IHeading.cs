using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface IHeading : IPublishedElement
{
    Umbraco.Cms.Core.Models.MediaWithCrops BackgroundImage { get; }

    string Title { get; }
}