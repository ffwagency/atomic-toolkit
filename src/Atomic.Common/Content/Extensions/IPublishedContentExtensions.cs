using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Atomic.Common.Content.Extensions;

public static class IPublishedContentExtensions
{
	public static T? GetValueWithFallback<T>(this IPublishedContent publishedContent, IEnumerable<string>? fieldQueries, string? culture = null)
	{
		if (publishedContent == null || fieldQueries == null)
			return default;

		foreach (var fieldQuery in fieldQueries)
		{
			T? result = fieldQuery.Contains('/')
				? GetValueFromBlockListComponents<T>(publishedContent, fieldQuery, GetValueMode.FirstAvailableValueInComponent, culture).FirstOrDefault()
				: GetValueFromPublishedContent<T>(publishedContent, fieldQuery, culture);
			if (ResultHasValue(result))
				return result;
		}

		return default;
	}

	public static IEnumerable<T> CollectValues<T>(this IPublishedContent publishedContent, IEnumerable<string> fieldQueries, string? culture = null)
	{
		if (publishedContent == null || fieldQueries == null)
			return Enumerable.Empty<T>();

		var values = new List<T>();

		foreach (var fieldQuery in fieldQueries)
		{
			if (fieldQuery.Contains('/'))
			{
				var blockListValues = GetValueFromBlockListComponents<T>(publishedContent, fieldQuery, GetValueMode.AvailableValuesFromAllComponents, culture);
				values.AddRange(blockListValues);
			}
			else
			{
				var publishedContentValue = GetValueFromPublishedContent<T>(publishedContent, fieldQuery, culture);
				if (ResultHasValue(publishedContentValue))
					values.Add(publishedContentValue!);
			}
		}

		return values;
	}

	public static bool FieldVariesByCulture(this IPublishedContent publishedContent, string alias)
	{
		return publishedContent?.GetProperty(alias)?.PropertyType?.VariesByCulture() == true;
	}

	public static bool FieldVariesByCulture(this IPublishedElement publishedElement, string alias)
	{
		return publishedElement?.GetProperty(alias)?.PropertyType?.VariesByCulture() == true;
	}

	private static IEnumerable<IPublishedElement> GetBlockListElements(IPublishedContent publishedContent, string field, string elementAlias, string? culture = null)
	{
		var blockListElements = publishedContent.FieldVariesByCulture(field)
			? (publishedContent.Value<IEnumerable<BlockListItem>>(field, culture)?
												.Select(x => x.Content)
												.Where(x => x.ContentType.Alias == elementAlias))
			: (publishedContent.Value<IEnumerable<BlockListItem>>(field)?
												.Select(x => x.Content)
												.Where(x => x.ContentType.Alias == elementAlias));

		return blockListElements ?? Enumerable.Empty<IPublishedElement>();
	}

	private static List<T> GetValueFromBlockListComponents<T>(IPublishedContent publishedContent, string fieldQuery, GetValueMode mode, string? culture)
	{
		var blockListsQuery = fieldQuery.Split('/', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();
		var fields = blockListsQuery.Last().Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
		blockListsQuery.RemoveAt(blockListsQuery.Count - 1);

		var blockListElements = new List<IPublishedElement>();

		foreach (var blockListQuery in blockListsQuery)
		{
			var blockListQueryParts = blockListQuery.Split('[');
			var blockListField = blockListQueryParts[0];
			var blockListElementAlias = blockListQueryParts[1].TrimEnd(']');

			if (blockListElements.Count == 0)
				blockListElements = GetBlockListElements(publishedContent, blockListField, blockListElementAlias, culture).ToList();
			else
				blockListElements = GetNestedTargetElements(blockListElements, blockListField, blockListElementAlias, culture).ToList();

			if (blockListElements.Count == 0)
				break;
		}

		var values = new List<T>();

		foreach (var field in fields)
		{
			foreach (var blockListElement in blockListElements)
			{
				if (blockListElement == null)
					continue;

				T? result;

				if (blockListElement.FieldVariesByCulture(field))
					result = blockListElement.Value<T>(field, culture);
				else
					result = blockListElement.Value<T>(field);

				if (ResultHasValue(result))
					values.Add(result!);

				if (mode == GetValueMode.FirstAvailableValueInComponent && values.Count > 0)
					return values;
			}
		}

		return values;
	}

	private static T? GetValueFromPublishedContent<T>(IPublishedContent publishedContent, string field, string? culture)
	{
		if (publishedContent.FieldVariesByCulture(field))
			return publishedContent.Value<T>(field, culture);
		else
			return publishedContent.Value<T>(field);
	}

	private static bool ResultHasValue<T>(T? result)
	{
		switch (result)
		{
			case string stringResult:
				if (!string.IsNullOrWhiteSpace(stringResult))
					return true;
				break;
			default:
				if (result != null)
					return true;
				break;
		}

		return false;
	}

	private static IEnumerable<IPublishedElement> GetNestedTargetElements(IEnumerable<IPublishedElement> blockListElements, string field, string elementAlias, string? culture = null)
	{
		var resultBlockListElements = Enumerable.Empty<IPublishedElement>();

		foreach (var blockListElement in blockListElements)
		{
			var nestedElements = blockListElement.FieldVariesByCulture(field)
				? (blockListElement.Value<IEnumerable<BlockListItem>>(field, culture)?
													.Select(x => x.Content)
													.Where(x => x.ContentType.Alias == elementAlias))
				: (blockListElement.Value<IEnumerable<BlockListItem>>(field)?
													.Select(x => x.Content)
													.Where(x => x.ContentType.Alias == elementAlias));

			if (nestedElements != null)
				resultBlockListElements = resultBlockListElements.Concat(nestedElements);
		}

		return resultBlockListElements;
	}

	private enum GetValueMode
	{
		FirstAvailableValueInComponent,
		AvailableValuesFromAllComponents
	}
}