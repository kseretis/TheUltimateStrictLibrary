using TheUltimateStrictLibrary.Extensions;

namespace Tests.Extensions;

[TestClass]
public class RegexExtensionsTest
{
    [TestMethod]
    [DataRow("abc", false)]
    [DataRow("abcτθ", true)]
    [DataRow("του", true)]
    [DataRow("θζ-makis", true)]
    [DataRow("Μακης", true)]
    [DataRow("makisά", true)]
    [DataRow("", false)]
    [DataRow(" ", false)]
    public void ContainsNonLatinCharacter_WithValues_ShouldReturn(string value, bool shouldBe)
    {
        Assert.AreEqual(value.ContainsNonLatinCharacters(), shouldBe);
    }

    [TestMethod]
    [DataRow("ab@c", false)]
    [DataRow("ab@@c", true)]
    [DataRow("", false)]
    [DataRow("makis@test.com", false)]
    [DataRow("makis@@test.com", true)]
    [DataRow("makis@@@test.com", true)]
    public void ContainsMoreThanOneAtInTheRow_WithValues_ShouldReturn(string value, bool shouldBe)
    {
        Assert.AreEqual(value.ContainsMoreThanOneAtInTheRow(), shouldBe);
    }
    
    [TestMethod]
    [DataRow("ab@c", false)]
    [DataRow("ab..c", true)]
    [DataRow(".", false)]
    [DataRow("makis@test.com", false)]
    [DataRow("makis@test..com", true)]
    [DataRow("makis@test...com.com", true)]
    public void ContainsMoreThanOneDotInTheRow_WithValues_ShouldReturn(string value, bool shouldBe)
    {
        Assert.AreEqual(value.ContainsMoreThanOneDotInTheRow(), shouldBe);
    }
    
    [TestMethod]
    [DataRow("ab-c", false)]
    [DataRow("-a-b-c", false)]
    [DataRow("-", false)]
    [DataRow("--", true)]
    [DataRow("mak-is@test.com", false)]
    [DataRow("mak--is@test.com", true)]
    [DataRow("m---akis@test...com.com", true)]
    public void ContainsMoreThanOneHyphenInTheRow_WithValues_ShouldReturn(string value, bool shouldBe)
    {
        Assert.AreEqual(value.ContainsMoreThanOneHyphenInTheRow(), shouldBe);
    }
    
    [TestMethod]
    [DataRow("ab_c", false)]
    [DataRow("a_b_c", false)]
    [DataRow("_", false)]
    [DataRow("__", true)]
    [DataRow("mak_is@test.com", false)]
    [DataRow("mak__is@test.com", true)]
    [DataRow("m___akis@test...com.com", true)]
    public void ContainsMoreThanOneUnderscoreInTheRow_WithValues_ShouldReturn(string value, bool shouldBe)
    {
        Assert.AreEqual(value.ContainsMoreThanOneUnderscoreInTheRow(), shouldBe);
    }
}