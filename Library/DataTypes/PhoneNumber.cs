using System.Text.RegularExpressions;
using TheUltimateStrictLibrary.Enums;
using TheUltimateStrictLibrary.Exceptions;
using TheUltimateStrictLibrary.Extensions;
using TheUltimateStrictLibrary.DataTypes;

namespace TheUltimateStrictLibrary.DataTypes;

public class PhoneNumber : DataType<string>
{
    private const int ActualLength = 13;

    public CountryCode CountryCode { get; private set; }
    public string Number { get; private set; } = null!;
    
    public override string Value
    {
        get => CountryCode + Number;
        set
        {
            ValidateValue(value);
            CountryCode = value!.GetCountryCodeFromPhoneNumber();
            Number = value[3..]; // FIXME 
        }
    }

    public PhoneNumber(string value)
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
        
        if (OverrideDefaultValidation is not null)
        {
            OverrideDefaultValidation(arg);
        }
        else
        {
            // TODO
            arg = Regex.Replace(arg!, @"\s+", "");

            if (arg!.Length.Equals(ActualLength))
            {
                throw new InvalidDataTypeException(
                    $"Value's length of type '{this}' must be 13 characters, 3 for country code and 10 the actual number!");
            }

            if (arg!.ContainsLetter())
            {
                throw new InvalidDataTypeException(arg, this, "mustn't contain any letter!");
            }

            // TODO contains any other symbol except +
        }
        
        ExtraValidation?.Invoke(arg);
    }
}

