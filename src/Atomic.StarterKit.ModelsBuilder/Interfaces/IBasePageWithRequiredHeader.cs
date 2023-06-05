using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface IBasePageWithRequiredHeader : IPublishedContent
{
    Umbraco.Cms.Core.Models.Blocks.BlockListModel PageHeader { get; }
}