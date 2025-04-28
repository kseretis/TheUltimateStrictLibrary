using TheUltimateStrictLibrary.Extensions;

namespace Tests.Extensions;

[TestClass]
public class StringExtensionsTest
{
    [TestMethod]
    [DataRow("tung tung tung", false)]
    [DataRow("", true)]
    [DataRow("  ", true)]
    [DataRow("assasino", false)]
    [DataRow(null, true)]
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
    [DataRow("abc-123", true)]
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
    [DataRow("Makis", false)]
    [DataRow("Makis Kots", true)]
    [DataRow("", false)]
    [DataRow("  ", true)]
    [DataRow("123", false)]
    [DataRow("makis123 4", true)]
    [DataRow("makis- 123", true)]
    public void ContainsWhiteSpace_WithValue_ShouldReturn(string value, bool shouldBe)
    {
        Assert.AreEqual(value.ContainsWhiteSpace(), shouldBe);
    }
}
