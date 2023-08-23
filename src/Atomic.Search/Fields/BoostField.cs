using Atomic.Search.Fields.Base;

namespace Atomic.Search.Fields;

public class BoostField : SearchField
{
    public BoostField() : base("searchBoost", true)
    { }
}