using TheUltimateStrictLibrary.Exceptions;
using TheUltimateStrictLibrary.Extensions;

namespace TheUltimateStrictLibrary.DataTypes;

public class Name : DataType<string>
{
    public override string Value
    {
        get => value;
        set
        {
            ValidateValue(value);
            base.value = value;
        }
    }

    public Name(string value)
    {
        Value = value;
    }

    public Name(string value, CustomValidation<string> extraValidation)
    {
        ExtraValidation = extraValidation;
        Value = value;
    }
    
    protected override void ApplyStrictDataTypeValidations(string arg)
    {
        if (arg.IsBlank())
        {
            throw new InvalidDataTypeException(arg, this, "can't be empty or contain any whitespace!");
        }
        
        if (arg.ContainsNumber())
        {
            throw new InvalidDataTypeException(arg, this, "contains at least a number!");
        }

        if (arg.ContainsSymbol())
        {
            throw new InvalidDataTypeException(arg, this, "contains at least a symbol!");
        }
    }
}
