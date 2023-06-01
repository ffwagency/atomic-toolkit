using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface IContact : IPublishedElement
{
    string AcceptanceText { get; }

    string EmbededGoogleMap { get; }

    string FormTitle { get; }

    IEnumerable<Umbraco.Cms.Core.Models.Link> LinkToTermsAndConditionsPage { get; }
}