using Lib.Exceptions;
using Lib.Extensions;

namespace Lib.Validators
{
    public abstract class IValidator<T>
    {
        public abstract void ValidateValue(T? value);

        public void ValidateIsNotNullOrEmpty(string? value)
        {
            if (value.IsBlank())
            {
                throw new InvalidTypeException("Value is null/empty!");
            }
        }
    }
}
