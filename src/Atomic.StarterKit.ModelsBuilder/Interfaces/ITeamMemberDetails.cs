using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.ModelsBuilder.Interfaces;

public interface ITeamMemberDetails : IPublishedElement
{
    string Description { get; }

    string FacebookProfileLink { get; }

    string Footnote { get; }

    Umbraco.Cms.Core.Models.MediaWithCrops Image { get; }

    string InstagramProfileLink { get; }

    string MemberName { get; }

    string MemberResume { get; }

    string Title { get; }
}