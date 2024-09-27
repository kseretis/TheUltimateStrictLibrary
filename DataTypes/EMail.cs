using TheUltimateStrictLibrary.Validators;

namespace TheUltimateStrictLibrary.DataTypes
{
    public class EMail
    {
        private string? _address;
        private string? _domain;
        private string? _suffix;
        
        public string? Address { get; }
        public string? Domain { get; }
        public string? Suffix { get; }

        public string? Value
        {
            get => String.Join(null, _address, "@", _domain, _suffix);
            set
            {
                Validator.IsAnEmail(value);
                
                var splitValue = value!.Split("@");
                _address = splitValue[0];

                var splitDomain = splitValue[1].Split(".");
                _domain = splitDomain[0];
                _suffix = splitDomain[1];
            }
        }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public EMail() { }

        /// <summary>
        /// Constructor with value and validation
        /// </summary>
        /// <param name="value">The whole email address</param>
        public EMail(string value)
        {
            Value = value;
        }
    }
}
