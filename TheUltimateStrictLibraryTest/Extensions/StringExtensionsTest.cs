using TheUltimateStrictLibrary.Extensions;

namespace TheUltimateStrictLibraryTest.Extensions;

[TestClass]
public class StringExtensionsTest
{
    [TestMethod]
    [DataRow("dasd", false)]
    [DataRow("", true)]
    [DataRow("  ", true)]
    [DataRow("dasd dqwdsa", false)]
    public void IsBlank_WithValue_ShouldReturn(string value, bool shouldBe)
    {
        Assert.AreEqual(value.IsBlank(), shouldBe);
    }

    [TestMethod]
    [DataRow("123", true)]
    [DataRow("abc", false)]
    [DataRow("abc123", true)]
    [DataRow("", false)]
    [DataRow(" ", false)]
    [DataRow("abc 123", true)]
    public void ContainsNumber_WithValue_ShouldReturn(string value, bool shouldBe)
    {
        Assert.AreEqual(value.ContainsNumber(), shouldBe);
    }

    [TestMethod]
    [DataRow("!@#", true)]
    [DataRow("abc!", true)]
    [DataRow("123$", true)]
    [DataRow("abc123", false)]
    [DataRow("", false)]
    [DataRow(" ", false)]
    [DataRow("abc 123", false)]
    public void ContainsSymbol_WithValue_ShouldReturn(string value, bool shouldBe)
    {
        Assert.AreEqual(value.ContainsSymbol(), shouldBe);
    }

    [TestMethod]
    [DataRow("abc", true)]
    [DataRow("123", false)]
    [DataRow("abc123", true)]
    [DataRow("%^d123", true)]
    [DataRow("", false)]
    [DataRow(" ", false)]
    [DataRow("abc 123", true)]
    public void ContainsLetter_WithValue_ShouldReturn(string value, bool shouldBe)
    {
        Assert.AreEqual(value.ContainsLetter(), shouldBe);
    }

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
}
