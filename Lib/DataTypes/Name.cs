using Lib.Exceptions;
using Lib.Extensions;
using Lib.Validators;

namespace Lib.DataTypes
{
    public class Name : IValidator<string>
    {
        private string? _value;

        public string? Value
        {
            get => _value;
            set
            {
                ValidateValue(value);
                _value = value;
            }
        }
        
        /// <summary>
        /// Empty Constructor
        /// </summary>
        public Name() { }

        /// <summary>
        /// Constructor with value and validation
        /// </summary>
        /// <param name="value">The actual name</param>
        public Name(string? value)
        {
            Value = value;
        }

        public override void ValidateValue(string? value)
        {
            ValidateIsNotNullOrEmpty(value);

            if (value!.ContainANumber())
            {
                throw new InvalidTypeException($"Value: '{value}' contains at least a number!");
            }

            if (value!.ContainASymbol())
            {
                throw new InvalidTypeException($"Value '{value}' contains at least a symbol!");
            }
        }
    }
}
