using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public partial interface IBasePage : IPublishedContent
{
    Umbraco.Cms.Core.Models.Blocks.BlockListModel PageHeader { get; }
}