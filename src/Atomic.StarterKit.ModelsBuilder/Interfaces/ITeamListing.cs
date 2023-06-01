using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface ITeamListing : IPublishedElement
{
    string Description { get; }

    Umbraco.Cms.Core.Models.Blocks.BlockListModel Members { get; }

    string Title { get; }
}