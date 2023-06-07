namespace Atomic.Sео.Html.Validators
{
    internal static class DescriptionValidator
    {
        internal static bool HasNoDesctiption(this string? text)
        {
            return string.IsNullOrWhiteSpace(text);
        }
    }
}
