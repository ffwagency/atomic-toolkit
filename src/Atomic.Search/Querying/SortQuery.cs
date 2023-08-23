using Atomic.Search.Fields.Base;
using Atomic.Search.Models;

namespace Atomic.Search.Querying;

public class SortQuery
{
    public SortQuery()
    {
        SortableFields = new List<KeyValuePair<ISearchFieldIdentifier, SortOrder>>();
    }

    internal List<KeyValuePair<ISearchFieldIdentifier, SortOrder>> SortableFields { get; }

    internal bool IsEmpty => SortableFields.Count == 0;

    public SortQuery SortBy<T>(SortOrder sortOrder =  SortOrder.Asc)
        where T : SearchField, ISortable
    {
        SortableFields.Add(new KeyValuePair<ISearchFieldIdentifier, SortOrder>(
            new TypeSearchFieldIdentifier(typeof(T)), sortOrder));

        return this;
    }

    public SortQuery SortBy(string? searchFieldKey, SortOrder sortOrder = SortOrder.Asc)
    {
        if (string.IsNullOrWhiteSpace(searchFieldKey))
            return this;

        SortableFields.Add(new KeyValuePair<ISearchFieldIdentifier, SortOrder>(
            new KeySearchFieldIdentifier(searchFieldKey),
            sortOrder));

        return this;
    }

    public static SortQuery Empty => new();
}