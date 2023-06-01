using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface IPortfolioDetails : IPublishedElement
{
    Umbraco.Cms.Core.Strings.IHtmlEncodedString Description { get; }

    Umbraco.Cms.Core.Models.MediaWithCrops MainImage { get; }

    string PreTitle { get; }

    IEnumerable<Umbraco.Cms.Core.Models.MediaWithCrops> RelatedImages { get; }

    string RelatedImagesSectionTitle { get; }

    string Title { get; }
}