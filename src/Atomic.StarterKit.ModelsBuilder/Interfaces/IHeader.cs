using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface IHeader : IPublishedElement
{
    string BrandText { get; }

    Umbraco.Cms.Core.Models.MediaWithCrops Logo { get; }

    Umbraco.Cms.Core.Models.Blocks.BlockListModel MainNavigation { get; }
}