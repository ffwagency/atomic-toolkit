using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface IServices : IPublishedElement
{
    string PreTitle { get; }

    Umbraco.Cms.Core.Models.Blocks.BlockListModel ServicesItems { get; }

    string Title { get; }
}