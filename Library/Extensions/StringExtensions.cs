using System.Text.RegularExpressions;

namespace TheUltimateStrictLibrary.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Checks if a string is null or empty
    /// </summary>
    /// <param name="value"></param>
    /// <returns>True for null/empty values</returns>
    public static bool IsBlank(this string? value)
    {
        return string.IsNullOrWhiteSpace(value);
    }

    public static bool ContainsNumber(this string value)
    {
        return value.Any(char.IsNumber);
    }

    public static bool ContainsSymbol(this string value)
    {
        return value.Any(c => !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c));
    }

    public static bool ContainsLetter(this string value)
    {
        return value.Any(char.IsLetter);
    }

    public static bool ContainsWhiteSpace(this string value)
    {
        return value.Any(char.IsWhiteSpace);
    }

    public static bool ContainsNonLatinCharacters(this string value)
    {
        return Regex.IsMatch(value, @"[^\u0000-\u024F]", RegexOptions.None);
    }
}
