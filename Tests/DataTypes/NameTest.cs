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
}
