using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface ITimeline : IPublishedElement
{
    string PreTitle { get; }

    Umbraco.Cms.Core.Models.Blocks.BlockListModel TimelineItems { get; }

    string Title { get; }
}