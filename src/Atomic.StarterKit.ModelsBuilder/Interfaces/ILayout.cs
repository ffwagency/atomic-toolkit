using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface ILayout : IPublishedContent
{
    Umbraco.Cms.Core.Models.Blocks.BlockListModel Footer { get; }

    Umbraco.Cms.Core.Models.Blocks.BlockListModel Header { get; }
}