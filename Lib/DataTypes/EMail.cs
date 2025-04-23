using TheUltimateStrictLibrary.Exceptions;
using TheUltimateStrictLibrary.Extensions;
using TheUltimateStrictLibrary.Validators;

namespace TheUltimateStrictLibrary.DataTypes;

public class EMail : IValidator<string>
{
    private const char Dot = '.';
    private const char At = '@';

    public string? Address { get; private set; }
    public string? Domain { get; private set; }
    public string? TopLevelDomain { get; private set; }
    public string? Value
    {
        get => string.Concat(Address, At, Domain, TopLevelDomain);
        set
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

    /// <summary>
    /// Constructor with value and validation
    /// </summary>
    /// <param name="value">The whole email address</param>
    public EMail(string? value)
    {
        Value = value;
    }

    public override bool HasValue()
    {
        return !Value.IsBlank();
    }

    public override void ValidateValue(string? value)
    {
        ValidateIsNotNullOrEmpty(value);

        // FIXME 
        // if (!ContainASymbol(value!))
        // {
        //     throw new InvalidTypeException($"Value {value} doesn't contain any symbol");
        // }

        int numberOfAts = value!.Count(c => c.Equals('@'));

        if (numberOfAts > 1)
        {
            throw new InvalidTypeException($"Value '{value}' of type '{this}', contains more than one '@'");
        }
    }
}
