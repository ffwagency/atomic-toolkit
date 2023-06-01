using Atomic.StarterKit.ModelsBuilder.Interfaces;
using Umbraco.Cms.Core.Models.Blocks;

namespace Atomic.StarterKit.Models.Mapping;

public static class DesignPageModelMapingExtensions
{
	public static DesignPageViewModel MapToDesignPageViewModel(this IContentPage source)
	{
		var target = new DesignPageViewModel(source);
		var components = new List<BlockListItem>();
		var basePage = source as IBasePage;
		components.AddRange(basePage!.PageHeader!);
		components.AddRange(source.DynamicContent!);
		target.Components = new BlockListModel(components);
		return target;
	}

	public static DesignPageViewModel MapToDesignPageViewModel(this IHomePage source)
	{
		var target = new DesignPageViewModel(source);
		var components = new List<BlockListItem>();
		components.AddRange(source.DynamicContent!);
		target.Components = new BlockListModel(components);
		return target;
	}

	public static DesignPageViewModel MapToDesignPageViewModel(this IAboutPage source)
	{
		var target = new DesignPageViewModel(source);
		var components = new List<BlockListItem>();
		var basePage = source as IBasePage;
		components.AddRange(basePage!.PageHeader!);
		components.AddRange(source.DynamicContent!);
		target.Components = new BlockListModel(components);
		return target;
	}

	public static DesignPageViewModel MapToDesignPageViewModel(this IContactPage source)
	{
		var target = new DesignPageViewModel(source);
		var components = new List<BlockListItem>();
		var basePage = source as IBasePage;
		components.AddRange(basePage!.PageHeader!);
		components.AddRange(source.DynamicContent!);
		target.Components = new BlockListModel(components);
		return target;
	}

	public static DesignPageViewModel MapToDesignPageViewModel(this IGalleryPage source)
	{
		var target = new DesignPageViewModel(source);
		var components = new List<BlockListItem>();
		var basePage = source as IBasePage;
		components.AddRange(basePage!.PageHeader!);
		components.AddRange(source.DynamicContent!);
		target.Components = new BlockListModel(components);
		return target;
	}

	public static DesignPageViewModel MapToDesignPageViewModel(this IPortfolioPage source)
	{
		var target = new DesignPageViewModel(source);
		var components = new List<BlockListItem>();
		var basePage = source as IBasePage;
		components.AddRange(basePage!.PageHeader!);
		components.AddRange(source.DynamicContent!);
		target.Components = new BlockListModel(components);
		return target;
	}

	public static DesignPageViewModel MapToDesignPageViewModel(this IPortfolioSinglePage source)
	{
		var target = new DesignPageViewModel(source);
		var components = new List<BlockListItem>();
		var basePage = source as IBasePage;
		components.AddRange(basePage!.PageHeader!);
		components.AddRange(source.DynamicContent!);
		target.Components = new BlockListModel(components);
		return target;
	}

	public static DesignPageViewModel MapToDesignPageViewModel(this IServicesPage source)
	{
		var target = new DesignPageViewModel(source);
		var components = new List<BlockListItem>();
		var basePage = source as IBasePage;
		components.AddRange(basePage!.PageHeader!);
		components.AddRange(source.DynamicContent!);
		target.Components = new BlockListModel(components);
		return target;
	}

	public static DesignPageViewModel MapToDesignPageViewModel(this ITeamPage source)
	{
		var target = new DesignPageViewModel(source);
		var components = new List<BlockListItem>();
		var basePage = source as IBasePage;
		components.AddRange(basePage!.PageHeader!);
		components.AddRange(source.DynamicContent!);
		target.Components = new BlockListModel(components);
		return target;
	}

	public static DesignPageViewModel MapToDesignPageViewModel(this ITeamMemberPage source)
	{
		var target = new DesignPageViewModel(source);
		var components = new List<BlockListItem>();
		var basePage = source as IBasePage;
		components.AddRange(basePage!.PageHeader!);
		components.AddRange(source.DynamicContent!);
		target.Components = new BlockListModel(components);
		return target;
	}

    public static DesignPageViewModel MapToDesignPageViewModel(this IErrorPage source)
    {
        var target = new DesignPageViewModel(source);
        var components = new List<BlockListItem>();
        components.AddRange(source.DynamicContent!);
        target.Components = new BlockListModel(components);
        return target;
    }
}