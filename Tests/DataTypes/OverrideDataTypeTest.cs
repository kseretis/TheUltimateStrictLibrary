using TheUltimateStrictLibrary.DataTypes;
using TheUltimateStrictLibrary.Exceptions;

namespace Tests.DataTypes;

[TestClass]
public class OverrideDataTypeTest
{
    [TestMethod]
    [DataRow("Crocodilo")]
    public void CreateName_WithExtraValidation_ShouldReturn(string value)
    {
        var name = new Name(value, ShouldBeMoreThan5Characters);
        
        Assert.IsNotNull(name.ExtraValidation);
        Assert.AreEqual(name.Value, value);
    }

    [TestMethod]
    [DataRow("Croc")]
    public void CreateName_WithExtraValidation_ShouldThrow(string value)
    {
        Assert.ThrowsException<InvalidDataTypeException>(() => new Name(value, ShouldBeMoreThan5Characters));
    }
    
    [TestMethod]
    [DataRow("Crocodilo", "Crocodillo")]
    public void UpdateName_WithExtraValidation_ShouldReturn(string initValue, string updatedValue)
    {
        var name = new Name(initValue, ShouldBeMoreThan5Characters);
        name.Value = updatedValue;
        
        Assert.AreEqual(name.Value, updatedValue);
    }
    
    [TestMethod]
    [DataRow("Crocodilo", "Croc")]
    public void UpdateName_WithExtraValidation_ShouldThrow(string initValue, string updatedValue)
    {
        var name = new Name(initValue, ShouldBeMoreThan5Characters);
        
        Assert.ThrowsException<InvalidDataTypeException>(() => name.Value = updatedValue);
    }

    [TestMethod]
    [DataRow("Crocodilo1")]
    [DataRow("Crocodilo#")]
    [DataRow("Crocodilo#1")]
    public void CreateName_WithOverrideValidation_ShouldReturn(string value)
    {
        Name.OverrideDefaultValidation = ShouldBeMoreThan5Characters;
        var name = new Name(value);
        
        Assert.IsNotNull(Name.OverrideDefaultValidation);
        Assert.IsNotNull(value);
        Assert.AreEqual(name.Value, value);
    }
    
    [TestMethod]
    [DataRow("Croc")]
    public void CreateName_WithOverrideValidation_ShouldThrow(string value)
    {
        Name.OverrideDefaultValidation = ShouldBeMoreThan5Characters;
        Assert.ThrowsException<InvalidDataTypeException>(() => new Name(value));
    }
    
    [TestMethod]
    [DataRow("Crocodilo")]
    public void CreateName_WithOverrideValidationAndExtraValidation_ShouldReturn(string value)
    {
        Name.OverrideDefaultValidation = ShouldBeMoreThan5Characters;
        var name = new Name(value, ShouldBeMoreLessThan9Characters);
        
        Assert.IsNotNull(Name.OverrideDefaultValidation);
        Assert.IsNotNull(name.ExtraValidation);
        Assert.IsNotNull(value);
        Assert.AreEqual(name.Value, value);
    }
    
    [TestMethod]
    [DataRow("Crocodilos")]
    public void CreateName_WithOverrideValidationAndExtraValidation_ShouldThrow(string value)
    {
        Name.OverrideDefaultValidation = ShouldBeMoreThan5Characters;
        Assert.ThrowsException<InvalidDataTypeException>(() => new Name(value, ShouldBeMoreLessThan9Characters));
    }
    
    #region CustomValidations

    private static void ShouldBeMoreThan5Characters(string arg)
    {
        if (arg.Length < 5)
        {
            throw new InvalidDataTypeException(arg, typeof(Name), "is too short");
        } 
    }

    private static void ShouldBeMoreLessThan9Characters(string arg)
    {
        if (arg.Length > 9)
        {
            throw new InvalidDataTypeException(arg, typeof(Name), "is too big");
        }
    }
    
    #endregion
}