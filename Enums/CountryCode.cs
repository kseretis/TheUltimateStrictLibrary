namespace TheUltimateStrictLibrary.Enums
{
    public enum CountryCode
    {
        // TODO improve this enum
        Greece = 30,
        Mexico = 52
    }

    public static class CountryCodeExtension
    {
        /// <summary>
        /// Map the string to a country code value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static CountryCode ToCountryCode(this string value)
        {
            // TODO improve this extension
            return CountryCode.Greece;
        }   
    }
}
