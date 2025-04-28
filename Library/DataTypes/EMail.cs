using TheUltimateStrictLibrary.Exceptions;
using TheUltimateStrictLibrary.Extensions;
using TheUltimateStrictLibrary.Enums;

namespace TheUltimateStrictLibrary.DataTypes;

public class EMail : DataType<string>
{
    public string Address { get; private set; } = null!;
    public string Domain { get; private set; } = null!;
    public string TopLevelDomain { get; private set; } = null!;
    
    public override string Value
    {
        get => string.Concat(Address, Symbols.At, Domain, TopLevelDomain);
        protected set
        {
            ValidateValue(value);

            var splitValue = value!.Split(Symbols.At);
            Address = splitValue.First();

            var domainPart = splitValue.Last();
            var splitDomain = domainPart.Split(Symbols.Dot).ToList();

            TopLevelDomain = splitDomain.Last();
            splitDomain.Remove(TopLevelDomain);
            
            Domain = string.Join(Symbols.Dot, splitDomain);
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
            throw new InvalidDataTypeException(arg, this, "can't be empty or contain any whitespace!");
        }

        var symbols = GetSymbolsFromString(arg);
        
        if (AreSymbolsUnacceptable(symbols))
        {
            throw new InvalidDataTypeException(arg, this, "mustn't contain unacceptable symbols!");
        }

        var numberOfAts = symbols.Count(s => s.Equals(Symbols.At));
        if (numberOfAts is > 1 or 0)
        {
            throw new InvalidDataTypeException(arg, this, "contains zero or more than one '@'!");
        }
        
        var numberOfDots = symbols.Count(s => s.Equals(Symbols.Dot));
        if (numberOfDots > 1 && arg.ContainsMoreThanOneDotInTheRow())
        {
            throw new InvalidDataTypeException(arg, this, "contains more than one dots in the row!");
        }

        var numberOfHyphens = symbols.Count(s => s.Equals(Symbols.Hyphen));
        if (numberOfHyphens > 1 && arg.ContainsMoreThanOneHyphenInTheRow())
        {
            throw new InvalidDataTypeException(arg, this, "contains more than one hyphen in the row!");
        }
        
        var numberOfUnderscores = symbols.Count(s => s.Equals(Symbols.Underscore));
        if (numberOfUnderscores > 1 && arg.ContainsMoreThanOneUnderscoreInTheRow())
        {
            throw new InvalidDataTypeException(arg, this, "contains more than one underscore in the row!");
        }
        
        //TODO: the domain must only contain dots from symbols 

        if (arg.ContainsNonLatinCharacters())
        {
            throw new InvalidDataTypeException(arg, this, "contains at least one non latin character!");
        }
    }
    
    private static List<char> GetSymbolsFromString(string value)
    {
        List<char> symbols = [];
        
        var charArray = value.ToCharArray();
        
        symbols.AddRange(charArray.Where(c => !char.IsLetterOrDigit(c)));

        return symbols;
    }

    private static bool AreSymbolsUnacceptable(List<char> symbols)
    {
        return symbols.Where(s =>
            !(s.Equals(Symbols.At) || s.Equals(Symbols.Dot) || s.Equals(Symbols.Hyphen) ||
              s.Equals(Symbols.Underscore))).ToList().Count > 0;
    }
}
