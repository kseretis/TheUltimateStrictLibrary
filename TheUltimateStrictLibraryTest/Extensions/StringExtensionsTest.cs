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
    public void ContainANumber_WithValue_ShouldReturn(string value, bool shouldBe)
    {
        Assert.AreEqual(value.ContainANumber(), shouldBe);
    }

    [TestMethod]
    [DataRow("!@#", true)]
    [DataRow("abc!", true)]
    [DataRow("123$", true)]
    [DataRow("abc123", false)]
    [DataRow("", false)]
    [DataRow(" ", false)]
    [DataRow("abc 123", false)]
    public void ContainASymbol_WithValue_ShouldReturn(string value, bool shouldBe)
    {
        Assert.AreEqual(value.ContainASymbol(), shouldBe);
    }

    [TestMethod]
    [DataRow("abc", true)]
    [DataRow("123", false)]
    [DataRow("abc123", true)]
    [DataRow("%^d123", true)]
    [DataRow("", false)]
    [DataRow(" ", false)]
    [DataRow("abc 123", true)]
    public void ContainALetter_WithValue_ShouldReturn(string value, bool shouldBe)
    {
        Assert.AreEqual(value.ContainALetter(), shouldBe);
    }
}
