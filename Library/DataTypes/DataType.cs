using TheUltimateStrictLibrary.Exceptions;

namespace TheUltimateStrictLibrary.DataTypes;

public abstract class DataType<T>
{
    protected T value;

    public virtual T Value { get; protected set; }

    public abstract void ValidateValue(T arg);
    
    protected void ValidateIsNotNull(T? arg)
    {
        if (arg is null)
        {
            throw new InvalidTypeException( $"Value of type '{this}' can't be null!");
        }
    }
}
