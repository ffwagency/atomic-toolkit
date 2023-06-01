using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface ITeamPage : IPublishedContent
{
    Umbraco.Cms.Core.Models.Blocks.BlockListModel DynamicContent { get; }
}