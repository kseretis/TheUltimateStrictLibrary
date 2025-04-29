using TheUltimateStrictLibrary.DataTypes;
using TheUltimateStrictLibrary.Exceptions;

namespace Tests.DataTypes;

[TestClass]
public class EMailTest
{
    [TestMethod]
    [DataRow("makis@test.com")]
    [DataRow("makis.das@test.com")]
    [DataRow("makis.das@test.em.com")]
    [DataRow("Mk.das-re_of@test.com")]
    [DataRow("Mk.das-re_of@test.com")]
    public void CreateEMail_WithValues_ShouldReturn(string value)
    {
        var email = new EMail(value);
        Assert.IsNotNull(email);
        Assert.AreEqual(email.Value, value);
    }
    
    [TestMethod]
    [DataRow(null, "can't be null")]
    [DataRow("", "can't be empty")]
    [DataRow("   ", "can't be empty")]
    [DataRow("makis!@test.com", "unacceptable symbols")]
    [DataRow("&ma*kis!@test.com", "unacceptable symbols")]
    [DataRow("makis@@test.com", "contains zero or more than one '@'")]
    [DataRow("@makis@test.com", "contains zero or more than one '@'")]
    [DataRow("makis.test.com", "contains zero or more than one '@'")]
    [DataRow("makis@test..com", "more than one dots")]
    [DataRow("maki....s@test.com", "more than one dots")]
    [DataRow("makis---das@test.com", "more than one hyphen")]
    [DataRow("makis-das@t---est.com", "more than one hyphen")]
    [DataRow("makis__das@test.em.com", "more than one underscore")]
    [DataRow("makis-θ@test.com", "non latin character")]
    [DataRow("makis.θ@test.com", "non latin character")]
    [DataRow("μάκης@test.com", "non latin character")]
    public void CreateEMail_WithValues_ShouldThrow(string value, string exceptionMessage)
    {
        var exception = Assert.ThrowsException<InvalidDataTypeException>(() => new EMail(value));
        Assert.IsTrue(exception.Message.Contains(exceptionMessage));
    }
    
    [TestMethod]
    [DataRow("makis@test.com", "makis2@test.com")]
    [DataRow("makis.das@test.com", "makis.das@test.gr.com")]
    [DataRow("makis.das@test.em.com", "makis.das@test.com")]
    public void UpdateEMail_WithValues_ShouldReturn(string initValue, string updatedValue)
    {
        var email = new EMail(initValue);
        email.Value = updatedValue;
        Assert.AreEqual(email.Value, updatedValue);
    }
    
    [TestMethod]
    [DataRow("makis@test.com", "makis2@@test.com")]
    [DataRow("makis.das@test.com", "makis..das@test.gr.com")]
    [DataRow("makis.das@test.em.com", "makis. das@test.com")]
    public void UpdateEMail_WithValues_ShouldThrow(string initValue, string updatedValue)
    {
        var email = new EMail(initValue);
        Assert.ThrowsException<InvalidDataTypeException>(() => email.Value = updatedValue);
    }
}