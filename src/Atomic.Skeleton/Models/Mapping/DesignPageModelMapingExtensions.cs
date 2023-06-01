using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace Atomic.Skeleton.Models.Mapping;

public static class DesignPageModelMapingExtensions
{
    public static DesignPageViewModel MapToDesignPageViewModel(this HomePage source)
    {
        var target = new DesignPageViewModel(source);
        var components = new List<BlockListItem>();
        components.AddRange(source.DynamicContent!);
        target.Components = new BlockListModel(components);
        return target;
    }

    public static DesignPageViewModel MapToDesignPageViewModel(this ErrorPage source)
    {
        var target = new DesignPageViewModel(source);
        var components = new List<BlockListItem>();
        components.AddRange(source.DynamicContent!);
        target.Components = new BlockListModel(components);
        return target;
    }
}