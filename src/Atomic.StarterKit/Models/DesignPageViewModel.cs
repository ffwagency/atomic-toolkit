using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.Models;

public class DesignPageViewModel : ContentModel
{
	public string? CssClass { get; set; }

	public BlockListModel? Components { get; set; }

	public DesignPageViewModel(IPublishedContent content) : base(content) { }
}
