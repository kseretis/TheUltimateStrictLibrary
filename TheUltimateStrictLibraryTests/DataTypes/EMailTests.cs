using TheUltimateStrictLibrary.DataTypes;

namespace TheUltimateStrictLibraryTests.DataTypes;

public class EMailTests
{
    [Test]
    [TestCase("theAddress@test.com", "theAddress", "test" ,"com", "test.com")]
    [TestCase("theAddress@test.d.com", "theAddress", "test.d" ,"com", "test.d.com")]
    public void CreateEMail_WithValues_ShouldReturn(string email, string address, string provider, string tld, string domain)
    {
        var underTest = new EMail(email);
        
        Assert.That(underTest.Value, Is.EqualTo(email));
        Assert.That(underTest.Address, Is.EqualTo(address));
        Assert.That(underTest.Provider, Is.EqualTo(provider));
        Assert.That(underTest.TopLevelDomain, Is.EqualTo(tld));
        Assert.That(underTest.Domain, Is.EqualTo(domain));
    }
}