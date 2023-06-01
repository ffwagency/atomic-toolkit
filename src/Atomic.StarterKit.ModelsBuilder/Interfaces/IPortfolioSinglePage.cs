using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface IPortfolioSinglePage : IPublishedContent
{
    Umbraco.Cms.Core.Models.Blocks.BlockListModel DynamicContent { get; }
}