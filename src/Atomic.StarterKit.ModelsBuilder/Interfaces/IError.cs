using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface IError : IPublishedElement
{
    int ErrorCode { get; }

    string ErrorMessage { get; }

    IEnumerable<Umbraco.Cms.Core.Models.Link> RedirectPage { get; }
}