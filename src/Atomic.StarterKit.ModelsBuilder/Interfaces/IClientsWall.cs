using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface IClientsWall : IPublishedElement
{
    BlockListModel Clients { get; }

    string PreTitle { get; }

    string Title { get; }
}