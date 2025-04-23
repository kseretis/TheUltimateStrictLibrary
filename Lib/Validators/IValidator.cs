using TheUltimateStrictLibrary.Exceptions;
using TheUltimateStrictLibrary.Extensions;

namespace TheUltimateStrictLibrary.Validators;

public abstract class IValidator<T>
{
    public abstract void ValidateValue(T? value);

    public abstract bool HasValue();

    public void ValidateIsNotNullOrEmpty(string? value)
    {
        if (value.IsBlank())
        {
            throw new InvalidTypeException( $"Value of type '{this}' can't be null/empty!");
        }
    }
}
