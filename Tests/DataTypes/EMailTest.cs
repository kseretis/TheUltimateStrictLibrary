namespace TheUltimateStrictLibraryTest.DataTypes;

[TestClass]
public class EMailTest
{
    [TestMethod]
    [DataRow("makis@test.com")]
    [DataRow("makis.das@test.com")]
    [DataRow("makis.das@test.em.com")]
    [DataRow("Mk..das@test.em.com")]
    public void CreateEMail_WithValues_ShouldReturn(string value)
    {
        
    }
}