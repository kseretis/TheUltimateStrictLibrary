using System.Text.RegularExpressions;
using Lib.Enums;
using Lib.Exceptions;
using Lib.Extensions;
using Lib.Validators;

namespace Lib.DataTypes
{
    public class PhoneNumber : IValidator<string>
    {
        private const int ActualLength = 13;
 
        public CountryCode? CountryCode { get; private set; }
        public string? Number { get; private set; }
        public string? Value
        {
            get => CountryCode + Number;
            set
            {
                ValidateValue(value);
                CountryCode = value!.GetCountryCodeFromPhoneNumber();
                Number = value[3..]; // FIXME 
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

        public override void ValidateValue(string? value)
        {
            ValidateIsNotNullOrEmpty(value);

            // TODO
            value = Regex.Replace(value!, @"\s+", "");

            if (value!.Length.Equals(ActualLength))
            {
                throw new InvalidTypeException($"Phone number length should be 13 charachters, 3 for country code and 10 the number!");
            }

            if (value!.ContainALetter())
            {
                throw new InvalidTypeException($"Phone number can not contain any letter!");
            }

            // TODO contains any other symbol except +
        }
    }
}

