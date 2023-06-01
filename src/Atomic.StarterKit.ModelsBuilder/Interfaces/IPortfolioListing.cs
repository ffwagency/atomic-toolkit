using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface IPortfolioListing : IPublishedElement
{
    Umbraco.Cms.Core.Models.Blocks.BlockListModel PortfolioItems { get; }

    string PreTitle { get; }

    string Title { get; }
}