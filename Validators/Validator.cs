using TheUltimateStrictLibrary.Exceptions;

namespace TheUltimateStrictLibrary.Validators
{
    public static class Validator
    {
        public static void IsNullOrEmpty(string? value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new InvalidTypeException("Value is null/empty!");
            }
        }
        
        public static void IsAName(string? value)
        {
            IsNullOrEmpty(value);
            
            if (ContainANumber(value!))
            {
                throw new InvalidTypeException($"Value: '{value}' contains at least a number!");
            }
            
            if (ContainASymbol(value!))
            {
                throw new InvalidTypeException($"Value '{value}' contains at least a symbol!");
            }
        }

        public static void IsAPhoneNumber(string? value)
        {
            IsNullOrEmpty(value);

            if (ContainsALetter(value!))
            {
                throw new InvalidTypeException($"Phone number can not contain any letter!");
            }
        }

        public static void IsAnEmail(string? value)
        {
            IsNullOrEmpty(value);

            // FIXME 
            // if (!ContainASymbol(value!))
            // {
            //     throw new InvalidTypeException($"Value {value} doesn't contain any symbol");
            // }
            
            int numberOfAts = value!.Count(c => c.Equals('@'));

            if (numberOfAts > 1)
            {
                throw new InvalidTypeException($"Value {value} contains more than one '@'");
            }
        }

        #region Validations in character level 
        
        private static bool ContainANumber(string value)
        {
            return value.Any(char.IsNumber);
        }

        private static bool ContainASymbol(string value)
        {
            return value.Any(char.IsSymbol);
        }

        private static bool ContainsALetter(string value)
        {
            return value.Any(char.IsLetter);
        }
        
        #endregion    
    }
}
