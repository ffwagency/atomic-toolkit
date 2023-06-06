namespace Atomic.Sео.Html.Validators
{
	internal static class SeoSettingsValidator
	{
		internal static bool HasMetaDescriptionMaxLengthDefined(this int metaDescriptionMaxLength)
		{
			return metaDescriptionMaxLength != 0;
		}
	}
}
