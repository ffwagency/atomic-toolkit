using Atomic.Search.Fields.Base;

namespace Atomic.Search.Fields;

public class ExcludeFromSearchField : SearchField
{
    public ExcludeFromSearchField() : base("excludeFromSearch", true)
    { }
}