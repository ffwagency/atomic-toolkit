using Atomic.StarterKit.Models.Interfaces;
using Atomic.StarterKit.Models.ViewModels;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.StarterKit.Models.Mapping;

public static class DesignPageModelMapingExtensions
{
	public static DesignPageViewModel MapToDesignPageViewModel<T>(this T source) where T: IPublishedContent, IDynamicContent
    {
		var target = new DesignPageViewModel(source);
		var components = new List<BlockListItem>();
        if (source is IBasePageWithRequiredHeader basePage)
        {
            components.AddRange(basePage!.PageHeader);
        }
		components.AddRange(source.DynamicContent!);
		target.Components = new BlockListModel(components);
		return target;
	}
}