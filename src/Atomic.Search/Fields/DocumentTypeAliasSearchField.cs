using Atomic.Search.Fields.Base;

namespace Atomic.Search.Fields;

public class DocumentTypeAliasSearchField : SearchField
{
    public DocumentTypeAliasSearchField() : base("__NodeTypeAlias", false)
    { }
}