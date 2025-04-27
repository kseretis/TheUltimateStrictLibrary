using TheUltimateStrictLibrary.Exceptions;
using TheUltimateStrictLibrary.Extensions;
using TheUltimateStrictLibrary.DataTypes;

namespace TheUltimateStrictLibrary.DataTypes;

public class EMail : DataType<string>
{
    private const char Dot = '.';
    private const char At = '@';

    public string Address { get; private set; } = null!;
    public string Domain { get; private set; } = null!;
    public string TopLevelDomain { get; private set; } = null!;
    
    public override string Value
    {
        get => string.Concat(Address, At, Domain, TopLevelDomain);
        protected set
        {
            ValidateValue(value);

            var splitValue = value!.Split(At);
            Address = splitValue.First();

            var domainPart = splitValue.Last();
            var splitDomain = domainPart.Split(Dot).ToList();

            TopLevelDomain = splitDomain.Last();
            splitDomain.Remove(TopLevelDomain);
            
            Domain = string.Join(Dot, splitDomain);
        }
    }

    public EMail(string value)
    {
        Value = value;
    }
    
    public override void ValidateValue(string arg)
    {
        ValidateIsNotNull(arg);
        
        if (arg.IsBlank())
        {
            throw new InvalidTypeException($"Value '{arg}' of type '{this}', can't be empty!");
        }

        if (arg!.ContainsWhiteSpace())
        {
            throw new InvalidTypeException($"Value '{arg}' of type '{this}', mustn't contain any whitespace");
        }
        
        var numberOfAts = arg!.Count(c => c.Equals(At));

        if (numberOfAts > 1)
        {
            throw new InvalidTypeException($"Value '{arg}' of type '{this}', contains more than one '@'");
        }
    }
}
