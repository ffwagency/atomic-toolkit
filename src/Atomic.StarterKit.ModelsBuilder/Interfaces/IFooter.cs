using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface IFooter : IPublishedElement
{
    string BrandText { get; }

    string CopyrightText { get; }

    string Desciption { get; }

    Umbraco.Cms.Core.Models.Blocks.BlockListModel LeftColumnNavigation { get; }

    string LeftColumTitle { get; }

    Umbraco.Cms.Core.Models.MediaWithCrops Logo { get; }

    Umbraco.Cms.Core.Models.Blocks.BlockListModel MiddleColumnNavigation { get; }

    string MiddleColumnTitle { get; }

    Umbraco.Cms.Core.Models.Blocks.BlockListModel RightColumnNavigation { get; }

    string RightColumnTitle { get; }
}