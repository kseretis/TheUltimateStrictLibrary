using TheUltimateStrictLibrary.Exceptions;
using TheUltimateStrictLibrary.Extensions;

namespace TheUltimateStrictLibrary.Validators
{
    public abstract class IValidator<T>
    {
        public abstract void ValidateValue(T? value);

        public void ValidateIsNotNullOrEmpty(string? value)
        {
            if (value.IsNullOrEmpty())
            {
                throw new InvalidTypeException("Value is null/empty!");
            }
        }
    }
}
