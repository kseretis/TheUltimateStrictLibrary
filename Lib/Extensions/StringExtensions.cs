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
        return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
    }

    public static bool ContainANumber(this string value)
    {
        return value.Any(char.IsNumber);
    }

    public static bool ContainASymbol(this string value)
    {
        return value.Any(c => !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c));
    }

    public static bool ContainALetter(this string value)
    {
        return value.Any(char.IsLetter);
    }
}
