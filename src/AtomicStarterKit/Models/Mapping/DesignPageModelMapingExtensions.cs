using System.Collections.Generic;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace AtomicStarterKit.Models.Mapping;

public static class DesignPageModelMapingExtensions
{
	public static DesignPageViewModel MapToDesignPageViewModel(this ContentPage source)
	{
		var target = new DesignPageViewModel(source);
		var components = new List<BlockListItem>();
		components.AddRange(source.DynamicContent);
		target.Components = new BlockListModel(components);
		return target;
	}

	public static DesignPageViewModel MapToDesignPageViewModel(this HomePage source)
	{
		var target = new DesignPageViewModel(source);
		var components = new List<BlockListItem>();
		components.AddRange(source.DynamicContent);
		target.Components = new BlockListModel(components);
		return target;
	}

	public static DesignPageViewModel MapToDesignPageViewModel(this AboutPage source)
	{
		var target = new DesignPageViewModel(source);
		var components = new List<BlockListItem>();
		components.AddRange(source.DynamicContent);
		target.Components = new BlockListModel(components);
		return target;
	}

	public static DesignPageViewModel MapToDesignPageViewModel(this ContactPage source)
	{
		var target = new DesignPageViewModel(source);
		var components = new List<BlockListItem>();
		components.AddRange(source.DynamicContent);
		target.Components = new BlockListModel(components);
		return target;
	}

	public static DesignPageViewModel MapToDesignPageViewModel(this GalleryPage source)
	{
		var target = new DesignPageViewModel(source);
		var components = new List<BlockListItem>();
		components.AddRange(source.DynamicContent);
		target.Components = new BlockListModel(components);
		return target;
	}

	public static DesignPageViewModel MapToDesignPageViewModel(this PortfolioPage source)
	{
		var target = new DesignPageViewModel(source);
		var components = new List<BlockListItem>();
		components.AddRange(source.DynamicContent);
		target.Components = new BlockListModel(components);
		return target;
	}

	public static DesignPageViewModel MapToDesignPageViewModel(this PortfolioSinglePage source)
	{
		var target = new DesignPageViewModel(source);
		var components = new List<BlockListItem>();
		components.AddRange(source.DynamicContent);
		target.Components = new BlockListModel(components);
		return target;
	}

	public static DesignPageViewModel MapToDesignPageViewModel(this ServicesPage source)
	{
		var target = new DesignPageViewModel(source);
		var components = new List<BlockListItem>();
		components.AddRange(source.DynamicContent);
		target.Components = new BlockListModel(components);
		return target;
	}

	public static DesignPageViewModel MapToDesignPageViewModel(this TeamPage source)
	{
		var target = new DesignPageViewModel(source);
		var components = new List<BlockListItem>();
		components.AddRange(source.DynamicContent);
		target.Components = new BlockListModel(components);
		return target;
	}

	public static DesignPageViewModel MapToDesignPageViewModel(this TeamMemberPage source)
	{
		var target = new DesignPageViewModel(source);
		var components = new List<BlockListItem>();
		components.AddRange(source.DynamicContent);
		target.Components = new BlockListModel(components);
		return target;
	}
}