using Atomic.Search.Fields;
using Atomic.Search.Fields.Base;
using Atomic.Search.Models;

namespace Atomic.Search.Querying;

public class TextQuery
{
    public TextQuery(string? term, float? boost = null)
    {
        Term = new SingleValue(term, boost);
        SearchableFields = DefaultSearchableFields.ToHashSet();
    }

    internal SingleValue Term { get; private set; }

    internal HashSet<Type> SearchableFields { get; }

    internal bool IsEmpty => string.IsNullOrWhiteSpace(Term.Value) || !SearchableFields.Any();

    public TextQuery SetSearchTerm(string? term, float? boost = null)
    {
        Term = new SingleValue(term, boost);
        return this;
    }

    public TextQuery AddSearchableField<T>() where T : SearchField
    {
        SearchableFields.Add(typeof(T));
        return this;
    }

    public TextQuery ClearSearchableFields()
    {
        SearchableFields.Clear();
        return this;
    }

    public static TextQuery Empty => new(string.Empty);

    public static IEnumerable<Type> DefaultSearchableFields => new Type[] { typeof(TitleField), typeof(TextField) };
}