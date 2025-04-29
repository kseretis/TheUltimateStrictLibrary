using TheUltimateStrictLibrary.DataTypes;
using TheUltimateStrictLibrary.Exceptions;

namespace Tests.DataTypes;

[TestClass]
public class NameTest
{
    [TestMethod]
    [DataRow("John")]
    [DataRow("Doe")]
    [DataRow("Makis")]
    public void CreateName_WithValues_ShouldReturn(string value)
    {
        var name = new Name(value);
        Assert.AreEqual(name.Value, value);
    }

    [TestMethod]
    [DataRow("John!")]
    [DataRow("John123")]
    [DataRow("John@")]
    [DataRow("")]
    [DataRow("13")]
    [DataRow("&")]
    [DataRow(null)]
    public void CreateName_WithValues_ShouldThrow(string? value)
    {
        Assert.ThrowsException<InvalidDataTypeException>(() => new Name(value));
    }

    [TestMethod]
    [DataRow("John", "Johny")]
    [DataRow("Maakis", "Makis")]
    public void UpdateName_WithValues_ShouldReturn(string initValue, string updatedValue)
    {
        var name = new Name(initValue);
        name.Value = updatedValue;
        Assert.AreEqual(name.Value, updatedValue);
    }
    
    [TestMethod]
    [DataRow("John", "John1")]
    [DataRow("Makis", "Mak!s")]
    public void UpdateName_WithValues_ShouldThrow(string initValue, string updatedValue)
    {
        var name = new Name(initValue);
        Assert.ThrowsException<InvalidDataTypeException>(() => name.Value = updatedValue);
    }
}
