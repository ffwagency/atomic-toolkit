using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface INavigationItem : IPublishedElement
{
    IEnumerable<Umbraco.Cms.Core.Models.Link> Link { get; }

    IEnumerable<Umbraco.Cms.Core.Models.Link> SubMenuLinks { get; }
}