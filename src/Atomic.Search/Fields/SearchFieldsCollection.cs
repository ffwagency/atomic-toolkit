using Atomic.Search.Fields.Base;
using Atomic.Search.Fields.Exceptions;
using Umbraco.Cms.Core.Composing;
using Umbraco.Extensions;

namespace Atomic.Search.Fields;

public class SearchFieldsCollection : BuilderCollectionBase<SearchField>
{
    public SearchFieldsCollection(Func<IEnumerable<SearchField>> items)
        : base(items)
    { }

    public T? GetSearchField<T>() where T : SearchField => this.OfType<T>().FirstOrDefault();

    public SearchField? GetSearchField(string key)
        => this.OfType<SearchField>().FirstOrDefault(x => x.Key.InvariantEquals(key));

    public T GetRequiredSearchField<T>() where T : SearchField
    {
        var searchField = GetSearchField<T>();
        InvalidSearchFieldException.ThrowIfNull(searchField);
        return searchField!;
    }

    public SearchField GetRequiredSearchField(string key)
    {
        var searchField = GetSearchField(key);
        InvalidSearchFieldException.ThrowIfNull(searchField, key);
        return searchField!;
    }

    public IEnumerable<T> GetSearchFields<T>() where T : SearchField => this.OfType<T>();

    public SearchField? GetSearchField(Type type) => this.FirstOrDefault(x => x.GetType() == type);

    public SearchField GetRequiredSearchField(Type type)
    {
        var searchField = GetSearchField(type);

        InvalidSearchFieldException.ThrowIfNull(searchField);

        return searchField!;
    }

    public SearchField? GetSearchField(ISearchFieldIdentifier identifier)
    {
        return identifier switch
        {
            TypeSearchFieldIdentifier typeSearchFieldIdentifier => GetSearchField(typeSearchFieldIdentifier.Type),
            KeySearchFieldIdentifier keySearchFieldIdentifier => GetSearchField(keySearchFieldIdentifier.Key),
            _ => null,
        };
    }

    public SearchField GetRequiredSearchField(ISearchFieldIdentifier identifier)
    {
        var searchField = GetSearchField(identifier);

        var key = string.Empty;
        if (identifier is KeySearchFieldIdentifier keyIdentifiter)
            key = keyIdentifiter.Key;

        InvalidSearchFieldException.ThrowIfNull(searchField, key);

        return searchField!;
    }
}