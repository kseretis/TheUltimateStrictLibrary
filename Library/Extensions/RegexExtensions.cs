using System.Text.RegularExpressions;

namespace TheUltimateStrictLibrary.Extensions;

public static class RegexExtensions
{
    public static bool ContainsNonLatinCharacters(this string value)
    {
        return Regex.IsMatch(value, @"[^\u0000-\u024F]", RegexOptions.None);
    }

    public static bool ContainsMoreThanOneAtInTheRow(this string value)
    {
        return Regex.IsMatch(value, "@{2,}");
    }
    
    public static bool ContainsMoreThanOneDotInTheRow(this string value)
    {
        return Regex.IsMatch(value, @"\.{2,}");
    }
    
    public static bool ContainsMoreThanOneHyphenInTheRow(this string value)
    {
        return Regex.IsMatch(value, "-{2,}");
    }
    
    public static bool ContainsMoreThanOneUnderscoreInTheRow(this string value)
    {
        return Regex.IsMatch(value, "_{2,}");
    }
}