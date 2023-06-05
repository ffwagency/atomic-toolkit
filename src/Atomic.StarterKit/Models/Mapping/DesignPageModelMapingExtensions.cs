using Atomic.StarterKit.ModelsBuilder.Interfaces;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Atomic.StarterKit.Models.Mapping;

public static class DesignPageModelMapingExtensions
{
	public static DesignPageViewModel MapToDesignPageViewModel<T>(this T source) where T: IPublishedContent, IDynamicContent
    {
		var target = new DesignPageViewModel(source);
		var components = new List<BlockListItem>();
		var basePage = source as IBasePage;
        components.AddRange(basePage!.PageHeader!);
		components.AddRange(source.DynamicContent!);
		target.Components = new BlockListModel(components);
		return target;
	}

	public static DesignPageViewModel MapHeaderlessPageToDesignPageViewModel<T>(this T source) where T : IPublishedContent, IDynamicContent
    {
		var target = new DesignPageViewModel(source);
		var components = new List<BlockListItem>();
		components.AddRange(source.DynamicContent!);
		target.Components = new BlockListModel(components);
		return target;
	}
}