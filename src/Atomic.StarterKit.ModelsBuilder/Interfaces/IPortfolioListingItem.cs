using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface IPortfolioListingItem : IPublishedElement
{
    Umbraco.Cms.Core.Models.MediaWithCrops Image { get; }

    IEnumerable<Umbraco.Cms.Core.Models.Link> Link { get; }

    string PreTitle { get; }

    string Title { get; }
}