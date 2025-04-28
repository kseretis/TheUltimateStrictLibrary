using TheUltimateStrictLibrary.Exceptions;
using TheUltimateStrictLibrary.Extensions;
using TheUltimateStrictLibrary.DataTypes;

namespace TheUltimateStrictLibrary.DataTypes;

public class Name : DataType<string>
{
    public override string Value
    {
        get => value;
        protected set
        {
            ValidateValue(value);
            base.value = value;
        }
    }

    public Name(string value)
    {
        Value = value;
    }
    
    public override void ValidateValue(string arg)
    {
        ValidateIsNotNull(arg);

        if (arg.IsBlank())
        {
            throw new InvalidDataTypeException(arg, this, "can't be empty!");
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
