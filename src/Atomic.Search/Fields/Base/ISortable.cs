using Examine.Search;

namespace Atomic.Search.Fields.Base;

public interface ISortable
{
    SortType SortType { get; }
}