using Atomic.Search.Fields.Base;
using Atomic.Search.Models;
using Atomic.Search.Models.RangeValue;

namespace Atomic.Search.Querying;

public class FilterQuery
{
    public FilterQuery()
    {
        Filters = new List<KeyValuePair<ISearchFieldIdentifier, ISearchValue>>();
    }

    internal List<KeyValuePair<ISearchFieldIdentifier, ISearchValue>> Filters { get; }

    internal bool IsEmpty => Filters.Count == 0;

    public FilterQuery Add<TSearchField>(ISearchValue value)
      where TSearchField : SearchField
    {
        if (value == null)
            return this;

        switch (value)
        {
            case SingleValue singleValue:
                AddEqualsTo<TSearchField>(singleValue);
                break;
            case MultiValue multiValue:
                AddEqualsToAny<TSearchField>(multiValue);
                break;
            case IRangeValue rangeValue:
                AddInRange<TSearchField>(rangeValue);
                break;
        }

        return this;
    }

    public FilterQuery Add(string? searchFieldKey, ISearchValue value)
    {
        if (value == null)
            return this;

        switch (value)
        {
            case SingleValue singleValue:
                AddEqualsTo(searchFieldKey, singleValue);
                break;
            case MultiValue multiValue:
                AddEqualsToAny(searchFieldKey, multiValue);
                break;
            case IRangeValue rangeValue:
                AddInRange(searchFieldKey, rangeValue);
                break;
        }

        return this;
    }

    public FilterQuery AddEqualsTo<TSearchField>(string? value, float? boost = null)
        where TSearchField : SearchField
    {
        var singleValue = new SingleValue(value, boost);
        return AddEqualsTo<TSearchField>(singleValue);
    }

    public FilterQuery AddNotEqualsTo<TSearchField>(string? value, float? boost = null)
        where TSearchField : SearchField
    {
        var singleValue = new SingleValue(value, boost, true);
        return AddEqualsTo<TSearchField>(singleValue);
    }

    public FilterQuery AddEqualsTo<TSearchField>(SingleValue value)
       where TSearchField : SearchField
    {
        if (value?.IsEmpty == true)
            return this;

        Filters.Add(new KeyValuePair<ISearchFieldIdentifier, ISearchValue>(new TypeSearchFieldIdentifier(typeof(TSearchField)), value!));

        return this;
    }

    public FilterQuery AddEqualsTo(string? searchFieldKey, string? value, float? boost = null)
    {
        var singleValue = new SingleValue(value, boost);
        return AddEqualsTo(searchFieldKey, singleValue);
    }

    public FilterQuery AddNotEqualsTo(string? searchFieldKey, string? value, float? boost = null)
    {
        var singleValue = new SingleValue(value, boost, true);
        return AddEqualsTo(searchFieldKey, singleValue);
    }

    public FilterQuery AddEqualsTo(string? searchFieldKey, SingleValue value)
    {
        if (string.IsNullOrWhiteSpace(searchFieldKey) || value?.IsEmpty == true)
            return this;

        Filters.Add(new KeyValuePair<ISearchFieldIdentifier, ISearchValue>(new KeySearchFieldIdentifier(searchFieldKey), value!));

        return this;
    }

    public FilterQuery AddEqualsToAny<TSearchField>(MultiValue value)
       where TSearchField : SearchField
    {
        if (value?.IsEmpty == true)
            return this;

        Filters.Add(new KeyValuePair<ISearchFieldIdentifier, ISearchValue>(new TypeSearchFieldIdentifier(typeof(TSearchField)), value!));

        return this;
    }

    public FilterQuery AddEqualsToAny(string? searchFieldKey, MultiValue equalsToAny)
    {
        if (string.IsNullOrWhiteSpace(searchFieldKey) || equalsToAny?.IsEmpty == true)
            return this;

        Filters.Add(new KeyValuePair<ISearchFieldIdentifier, ISearchValue>(new KeySearchFieldIdentifier(searchFieldKey), equalsToAny!));

        return this;
    }

    public FilterQuery AddInRange<TSearchField>(double? min, double? max)
       where TSearchField : SearchField
    {
        var rangeValue = new DoubleRangeValue(min, max);
        return AddInRange<TSearchField>(rangeValue);
    }

    public FilterQuery AddInRange<TSearchField>(long? min, long? max)
     where TSearchField : SearchField
    {
        var rangeValue = new LongRangeValue(min, max);
        return AddInRange<TSearchField>(rangeValue);
    }

    public FilterQuery AddInRange<TSearchField>(IRangeValue value)
    where TSearchField : SearchField
    {
        if (value?.IsEmpty == true)
            return this;

        Filters.Add(new KeyValuePair<ISearchFieldIdentifier, ISearchValue>(new TypeSearchFieldIdentifier(typeof(TSearchField)), value!));

        return this;
    }

    public FilterQuery AddInRange(string? searchFieldKey, double? min, double? max)
    {
        var rangeValue = new DoubleRangeValue(min, max);
        return AddInRange(searchFieldKey, rangeValue);
    }

    public FilterQuery AddInRange(string? searchFieldKey, long? min, long? max)
    {
        var rangeValue = new LongRangeValue(min, max);
        return AddInRange(searchFieldKey, rangeValue);
    }

    public FilterQuery AddInRange(string? searchFieldKey, IRangeValue value)
    {
        if (string.IsNullOrWhiteSpace(searchFieldKey) || value?.IsEmpty == true)
            return this;

        Filters.Add(new KeyValuePair<ISearchFieldIdentifier, ISearchValue>(new KeySearchFieldIdentifier(searchFieldKey), value!));

        return this;
    }

    public static FilterQuery Empty => new();
}