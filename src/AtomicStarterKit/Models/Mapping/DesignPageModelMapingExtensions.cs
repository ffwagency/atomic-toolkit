using AtomicStarterKit.Models;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace AtomicStarterKit.Models.Mapping
{
	public static class DesignPageModelMapingExtensions
	{
		public static DesignPageViewModel MapToDesignPage(this ContentPage source)
		{
			var target = new DesignPageViewModel(source);
			var components = new List<BlockListItem>();
			components.AddRange(source.DynamicContent);
			target.Components = new BlockListModel(components);
			return target;
		}

		public static DesignPageViewModel MapToDesignPage(this HomePage source)
		{
			var target = new DesignPageViewModel(source);
			var components = new List<BlockListItem>();
			components.AddRange(source.DynamicContent);
			target.Components = new BlockListModel(components);
			return target;
		}

		public static DesignPageViewModel MapToDesignPage(this AboutPage source)
		{
			var target = new DesignPageViewModel(source);
			var components = new List<BlockListItem>();
			components.AddRange(source.DynamicContent);
			target.Components = new BlockListModel(components);
			return target;
		}

		public static DesignPageViewModel MapToDesignPage(this ContactPage source)
		{
			var target = new DesignPageViewModel(source);
			var components = new List<BlockListItem>();
			components.AddRange(source.DynamicContent);
			target.Components = new BlockListModel(components);
			return target;
		}

		public static DesignPageViewModel MapToDesignPage(this GalleryPage source)
		{
			var target = new DesignPageViewModel(source);
			var components = new List<BlockListItem>();
			components.AddRange(source.DynamicContent);
			target.Components = new BlockListModel(components);
			return target;
		}

		public static DesignPageViewModel MapToDesignPage(this PortfolioPage source)
		{
			var target = new DesignPageViewModel(source);
			var components = new List<BlockListItem>();
			components.AddRange(source.DynamicContent);
			target.Components = new BlockListModel(components);
			return target;
		}

		public static DesignPageViewModel MapToDesignPage(this PortfolioSinglePage source)
		{
			var target = new DesignPageViewModel(source);
			var components = new List<BlockListItem>();
			components.AddRange(source.DynamicContent);
			target.Components = new BlockListModel(components);
			return target;
		}

		public static DesignPageViewModel MapToDesignPage(this ServicesPage source)
		{
			var target = new DesignPageViewModel(source);
			var components = new List<BlockListItem>();
			components.AddRange(source.DynamicContent);
			target.Components = new BlockListModel(components);
			return target;
		}

		public static DesignPageViewModel MapToDesignPage(this TeamPage source)
		{
			var target = new DesignPageViewModel(source);
			var components = new List<BlockListItem>();
			components.AddRange(source.DynamicContent);
			target.Components = new BlockListModel(components);
			return target;
		}

		public static DesignPageViewModel MapToDesignPage(this TeamMemberPage source)
		{
			var target = new DesignPageViewModel(source);
			var components = new List<BlockListItem>();
			components.AddRange(source.DynamicContent);
			target.Components = new BlockListModel(components);
			return target;
		}
	}
}