using Atomic.Search.Models;

namespace Atomic.Search.Fields.Base;

public abstract class SearchField
{
    protected SearchField(string examineNameWithoutCulture,
        bool varyByCulture,
        float? boost = null)
    {
        ExamineNameWithoutCulture = examineNameWithoutCulture;
        VaryByCulture = varyByCulture;
        Boost = new Boost(boost);
    }

    public bool VaryByCulture { get; }

    public Boost Boost { get; private set; }

    public void SetBoost(float? value)
    {
        Boost = new Boost(value);
    }

    public void SetBoost(double? value)
    {
        Boost = new Boost(value);
    }

    public void SetBoost(decimal? value)
    {
        Boost = new Boost(value);
    }

    public virtual string Key => ExamineNameWithoutCulture;

    public string ExamineNameWithoutCulture { get; }
}