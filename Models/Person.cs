using TheUltimateStrictLibrary.DataTypes;

namespace TheUltimateStrictLibrary.Models;

public class Person
{
    public Guid Id { get; set; }
    public Name FirstName { get; set; } = new();
    public Name? MiddleName { get; set; }
    public Name LastName { get; set; } = new();
}