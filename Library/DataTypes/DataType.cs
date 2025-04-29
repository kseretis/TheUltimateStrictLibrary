using TheUltimateStrictLibrary.Exceptions;

namespace TheUltimateStrictLibrary.DataTypes;

public delegate void CustomValidation(string arg);

public abstract class DataType<T>
{
    public static CustomValidation? OverrideDefaultValidation { get; set; }
    
    public CustomValidation? ExtraValidation { get; protected init; }
    
    protected T value;

    public virtual T Value { get; set; } = default!;
    
    public abstract void ValidateValue(T arg);
    
    protected void ValidateIsNotNull(T? arg)
    {
        if (arg is null)
        {
            throw new InvalidDataTypeException( $"Value of type '{this}' can't be null!");
        }
    }
}
