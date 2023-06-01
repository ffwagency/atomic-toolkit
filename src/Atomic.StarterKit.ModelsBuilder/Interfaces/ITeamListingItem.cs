using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface ITeamListingItem : IPublishedElement
{
    string Description { get; }

    string FullName { get; }

    Umbraco.Cms.Core.Models.MediaWithCrops Image { get; }

    IEnumerable<Umbraco.Cms.Core.Models.Link> ProfileLink { get; }
}