using Umbraco.Cms.Core.Models.Blocks;

namespace Atomic.StarterKit.Models;

public interface IDynamicContent
{
    BlockListModel DynamicContent { get; }
}