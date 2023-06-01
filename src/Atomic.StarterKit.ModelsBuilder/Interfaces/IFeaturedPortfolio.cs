using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface IFeaturedPortfolio : IPublishedElement
{
    string PreTitle { get; }

    IEnumerable<Umbraco.Cms.Core.Models.Link> SeeMoreLink { get; }

    string Title { get; }
}