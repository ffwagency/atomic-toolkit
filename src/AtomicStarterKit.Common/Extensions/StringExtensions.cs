namespace AtomicStarterKit.Common.Extensions
{
    public static class StringExtensions
    {
        public static string CultureRegionToUpper(this string culture)
        {
            if (culture == null)
                return string.Empty;
            if (culture.Contains("-"))
            {
                var part = culture.Split('-');
                culture = $"{part[0]}-{part[1].ToUpper()}";
            }
            return culture;
        }
    }
}
