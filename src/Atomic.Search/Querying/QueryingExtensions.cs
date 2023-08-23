using Atomic.Search.Fields.Base;
using Atomic.Search.Fields.Exceptions;
using Atomic.Search.Models;
using Examine;
using Examine.Search;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Atomic.Search.Querying;

public static class QueryingExtensions
{
    public static IBooleanOperation SingleValueQuery(this IQuery query, SearchField searchField, SingleValue singleValue)
    {
        var boostedValue = singleValue.Value.Boost(singleValue.Boost.Value + searchField.Boost.Value);

        if (singleValue.IsNegation)
        {
            return searchField.VaryByCulture
                ? query.GroupedNot(new[] { searchField.ExamineNameWithoutCulture, ExamineNameWithCulture(searchField.ExamineNameWithoutCulture) }, boostedValue)
                : query.GroupedNot(new[] { searchField.ExamineNameWithoutCulture }, boostedValue);
        }

        return searchField.VaryByCulture
            ? query.GroupedOr(new[] { searchField.ExamineNameWithoutCulture, ExamineNameWithCulture(searchField.ExamineNameWithoutCulture) }, boostedValue)
            : query.Field(searchField.ExamineNameWithoutCulture, boostedValue);
    }

    public static IBooleanOperation MultiValueQuery(this IQuery query, SearchField searchField, MultiValue multiValue)
    {
        var boostedValues = multiValue.Values.Select(v => v.Value.Boost(v.Boost.Value + searchField.Boost.Value)).ToArray();

        if(multiValue.IsNegation)
        {
            return searchField.VaryByCulture
                ? query.GroupedNot(new[] { searchField.ExamineNameWithoutCulture, ExamineNameWithCulture(searchField.ExamineNameWithoutCulture) }, boostedValues)
                : query.GroupedNot(new[] { searchField.ExamineNameWithoutCulture }, boostedValues);
        }
        else
        {
            return searchField.VaryByCulture
                ? query.GroupedOr(new[] { searchField.ExamineNameWithoutCulture, ExamineNameWithCulture(searchField.ExamineNameWithoutCulture) }, boostedValues)
                : query.GroupedOr(new[] { searchField.ExamineNameWithoutCulture }, boostedValues);
        }
    }

    public static IBooleanOperation RangeValueQuery(this IQuery query, SearchField searchField, RangeValue rangeValue)
    {
        if (rangeValue.Type == typeof(long))
        {
            return searchField.VaryByCulture
                ? query.RangeQuery<long>(new[] { searchField.ExamineNameWithoutCulture, ExamineNameWithCulture(searchField.ExamineNameWithoutCulture) }, (long)rangeValue.Min, (long)rangeValue.Max)
                : query.RangeQuery<long>(new[] { searchField.ExamineNameWithoutCulture }, (long)rangeValue.Min, (long)rangeValue.Max);
        }
        else
        {
            return searchField.VaryByCulture
                ? query.RangeQuery<double>(new[] { searchField.ExamineNameWithoutCulture, ExamineNameWithCulture(searchField.ExamineNameWithoutCulture) }, (double)rangeValue.Min, (double)rangeValue.Max)
                : query.RangeQuery<double>(new[] { searchField.ExamineNameWithoutCulture }, (double)rangeValue.Min, (double)rangeValue.Max);
        }
    }

    public static INestedBooleanOperation GroupedOr(this INestedQuery query, SearchField searchField, params IExamineValue[] values)
    {
        return searchField.VaryByCulture
            ? query.GroupedOr(new[] { searchField.ExamineNameWithoutCulture, ExamineNameWithCulture(searchField.ExamineNameWithoutCulture) }, values)
            : query.GroupedOr(new[] { searchField.ExamineNameWithoutCulture }, values);
    }

    public static INestedBooleanOperation GroupedAnd(this INestedQuery query, SearchField searchField, params IExamineValue[] values)
    {
        return searchField.VaryByCulture
            ? query.GroupedAnd(new[] { searchField.ExamineNameWithoutCulture, ExamineNameWithCulture(searchField.ExamineNameWithoutCulture) }, values)
            : query.GroupedAnd(new[] { searchField.ExamineNameWithoutCulture }, values);
    }

    public static IOrdering OrderBy(this IBooleanOperation query, SearchField searchField)
    {
        InvalidSortableFieldException.ThrowIfNotOfType<ISortable>(searchField);

        return searchField.VaryByCulture
            ? query.OrderBy(new[] { new SortableField(searchField.ExamineNameWithoutCulture, ((ISortable)searchField).SortType),
                                    new SortableField(ExamineNameWithCulture(searchField.ExamineNameWithoutCulture), ((ISortable)searchField).SortType) })
            : query.OrderBy(new SortableField(searchField.ExamineNameWithoutCulture, ((ISortable)searchField).SortType));
    }

    public static IOrdering OrderByDescending(this IBooleanOperation query, SearchField searchField)
    {
        InvalidSortableFieldException.ThrowIfNotOfType<ISortable>(searchField);

        return searchField.VaryByCulture
            ? query.OrderByDescending(new[] { new SortableField(searchField.ExamineNameWithoutCulture, ((ISortable)searchField).SortType),
                                    new SortableField(ExamineNameWithCulture(searchField.ExamineNameWithoutCulture), ((ISortable)searchField).SortType) })
            : query.OrderByDescending(new SortableField(searchField.ExamineNameWithoutCulture, ((ISortable)searchField).SortType));
    }

    public static ISearchValue ToSearchValue(this string? value)
    {
        if (RangeValue.TryParse(value, out var rangeValue))
            return rangeValue!;

        if (MultiValue.TryParse(value, out MultiValue? multiValue))
            return multiValue!;

        return new SingleValue(value);
    }

    public static SingleValue ToSearchSingleValue(this string? value, float? boost = null, bool negate = false)
    {
        return new SingleValue(value, boost, negate);
    }

    public static string Sanitize(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return string.Empty;

        var regex = new Regex(@"[^\w\s\.-]");
        return regex.Replace(value, string.Empty);
    }

    private static string ExamineNameWithCulture(string examineNameWithoutCulture)
    {
        return $"{examineNameWithoutCulture}_{CultureInfo.CurrentCulture.ToString().ToLower()}";
    }
}