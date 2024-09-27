using TheUltimateStrictLibrary.Validators;

namespace TheUltimateStrictLibrary.DataTypes
{
    public class Name
    {
        private string? _value;

        public string? Value
        {
            get => _value;
            set
            {
                Validator.IsAName(value);
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
        public Name(string value)
        {
            Value = value;
        }
    }
}
