using Umbraco.Cms.Core.Models.Blocks;

namespace Atomic.StarterKit.Models.Interfaces;

public interface IDynamicContent
{
	BlockListModel DynamicContent { get; }
}