using TheUltimateStrictLibrary.Validators;

namespace TheUltimateStrictLibrary.DataTypes
{
    public class EMail
    {
        private const char Dot = '.';
        private const char At = '@';

        public string? Address { get; private set; }

        public string? Provider { get; private set; }

        public string? TopLevelDomain { get; private set; }

        public string? Domain { get; private set; }

        public string? Value
        {
            get => String.Join(null, Address, At, Domain);
            set
            {
                Validator.IsAnEmail(value);
                
                var splitValue = value!.Split(At);
                Address = splitValue.First();
                Domain = splitValue.Last();

                var splitDomain = Domain.Split(Dot).ToList();

                TopLevelDomain = splitDomain.Last();
                splitDomain.Remove(TopLevelDomain);
                
                Provider = String.Join(Dot, splitDomain);
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
