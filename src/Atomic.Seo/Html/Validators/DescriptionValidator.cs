namespace Atomic.Sео.Html.Validators
{
    internal static class DescriptionValidator
    {
        internal static bool HasDescription(this string? text)
        {
            return !string.IsNullOrWhiteSpace(text);
        }
    }
}
