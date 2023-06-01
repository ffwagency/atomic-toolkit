using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface IContactEntry : IPublishedContent
{
    string ContactName { get; }

    string Email { get; }

    string Message { get; }
}