using System.Text.RegularExpressions;
using System.Text;

namespace Atomic.Common.Content;

public static class StringExtensions
{
    public static string ReplaceMultiple(this string value, Dictionary<string, string>? replacements, ReplaceStrategy strategy = ReplaceStrategy.Default)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;
        if (replacements?.Any() != true)
            return value;

        var result = value;

        switch (strategy)
        {
            case ReplaceStrategy.Default:
                foreach (var replacement in replacements)
                    result = result.Replace(replacement.Key, replacement.Value, StringComparison.OrdinalIgnoreCase);
                break;
            case ReplaceStrategy.StringBuilder:
                var sb = new StringBuilder(result);
                foreach (var replacement in replacements)
                    sb.Replace(replacement.Key, replacement.Value);
                result = sb.ToString();
                break;
            case ReplaceStrategy.Regex:
                result = Regex.Replace(value, string.Join("|", replacements.Keys.ToArray()), (m) => replacements[m.Value]);
                break;
        }

        return result;
    }

    public static string RemoveNewLines(this string value, ReplaceStrategy strategy = ReplaceStrategy.Default)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;

        var replacements = new Dictionary<string, string>();
        replacements["\n\r"] = string.Empty;
        replacements.Add("\n", string.Empty);

        return value.ReplaceMultiple(replacements, strategy);
    }
}

public enum ReplaceStrategy
{
    Default,
    StringBuilder,
    Regex
}
