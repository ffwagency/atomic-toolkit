using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface IFeaturedPortfolioItem : IPublishedElement
{
    string Description { get; }

    Umbraco.Cms.Core.Models.MediaWithCrops Image { get; }

    IEnumerable<Umbraco.Cms.Core.Models.Link> Link { get; }

    string Title { get; }
}