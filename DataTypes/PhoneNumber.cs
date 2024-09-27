using TheUltimateStrictLibrary.Enums;
using TheUltimateStrictLibrary.Validators;

namespace TheUltimateStrictLibrary.DataTypes
{
    public class PhoneNumber
    {
        private CountryCode? _countryCode;
        private string? _number;
        
        public CountryCode? CountryCode { get; }
        public string? Number { get; }
        public string? Value
        {
            get => _countryCode + _number;
            set
            {
                Validator.IsAPhoneNumber(value);
                _countryCode = value!.ToCountryCode();
                _number = value[3..]; // FIXME 
            }
        }
        
        /// <summary>
        /// Empty Constructor
        /// </summary>
        public PhoneNumber() { }

        /// <summary>
        /// Constructor with value and validation
        /// </summary>
        /// <param name="value">The complete phone number (eg: +30 6979978486) </param>
        public PhoneNumber(string value)
        {
            Value = value;
        }
    }
}

