using TheUltimateStrictLibrary.Exceptions;

namespace TheUltimateStrictLibrary.DataTypes;

public delegate void CustomValidation<in T>(T arg);

public abstract class DataType<T>
{
    public static CustomValidation<T>? OverrideDefaultValidation { get; set; }
    
    public CustomValidation<T>? ExtraValidation { get; protected init; }
    
    protected T value;

    public virtual T Value { get; set; } = default!;
    
    protected void ValidateValue(T arg)
    {
        ValidateIsNotNull(arg);
        
        if (OverrideDefaultValidation is not null)
        {
            OverrideDefaultValidation(arg);
        }
        else
        {
            ApplyStrictDataTypeValidations(arg);
        }
        
        ExtraValidation?.Invoke(arg);
    }
    
    protected abstract void ApplyStrictDataTypeValidations(T arg);
    
    private void ValidateIsNotNull(T? arg)
    {
        if (arg is null)
        {
            throw new InvalidDataTypeException( $"Value of type '{this}' can't be null!");
        }
    }
}
