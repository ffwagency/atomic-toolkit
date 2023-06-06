namespace Atomic.Sео.Html.Validators
{
    internal static class DescriptionValidator
    {
        internal static bool HasDesctiption(this string? text)
        {
            return string.IsNullOrWhiteSpace(text);
        }
    }
}
