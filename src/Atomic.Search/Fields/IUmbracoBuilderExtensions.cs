using Atomic.Search.Indexing;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.DependencyInjection;

namespace Atomic.Search.Fields;

public static class IUmbracoBuilderExtensions
{
    public static SearchFieldsCollectionBuilder SearchFields(this IUmbracoBuilder builder)
        => builder.WithCollectionBuilder<SearchFieldsCollectionBuilder>();

    internal static IUmbracoBuilder ConfigureSearchFields(this IUmbracoBuilder builder)
    {
        builder.Services.ConfigureOptions<RegisterComputedFieldsDefinitonsInIndex>();
        builder.Components().Append<StoreComputedFieldsValuesInIndex>();

        builder.SearchFields()
          .Append<PathField>()
          .Append<TitleField>()
          .Append<TextField>()
          .Append<ReleaseDateField>()
          .Append<BoostField>()
          .Append<DocumentTypeAliasSearchField>()
          .Append<ExcludeFromSearchField>()
          .Append<InheritsSearchBasePage>();

        return builder;
    }
}