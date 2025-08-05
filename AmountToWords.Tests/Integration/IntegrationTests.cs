
using AmountToWords.Lib.Mapping;
using AmountToWords.Lib.Models;
using AmountToWords.Lib.Services;

namespace AmountToWords.Tests;

[TestClass]
public class IntegrationTests
{
    private NumberMaps _maps;
    private AmountToWordsConverter _converter;

    [TestInitialize]
    public void Setup()
    {
        // Arrange
        _maps = new NumberMaps();
        _converter = new AmountToWordsConverter(_maps);
    }

    [DataTestMethod]
    [DynamicData(nameof(GetAmountData), DynamicDataSourceType.Method)]
    public void ToString_ConvertsAmountAccurately(decimal amount, string expected)
    {
        // Arrange
        var dollarsAndCents = new DollarsAndCents(amount, _converter);

        // Act
        var result = dollarsAndCents.ToString();

        // Assert
        Assert.AreEqual(expected, result);
    }

    public static IEnumerable<object[]> GetAmountData()
    {
        yield return new object[] { 2523.04m, "Two thousand five hundred twenty-three and 04/100 dollars" };
        yield return new object[] { 1000.00m, "One thousand and 00/100 dollars" };
        yield return new object[] { 7.99m, "Seven and 99/100 dollars" };
        yield return new object[] { 0.00m, "Zero and 00/100 dollars" };
    }

    [DataTestMethod]
    [DynamicData(nameof(GetSignTestCases), DynamicDataSourceType.Method)]
    public void ToString_PrefixesNegativeAmountsCorrectly(decimal amount, string expected)
    {
        var result = new DollarsAndCents(amount, _converter).ToString();
        Assert.AreEqual(expected, result);
    }

    public static IEnumerable<object[]> GetSignTestCases()
    {
        yield return new object[] { 0.00m, "Zero and 00/100 dollars" };
        yield return new object[] { -0.01m, "Negative zero and 01/100 dollars" };
        yield return new object[] { 125.85m, "One hundred twenty-five and 85/100 dollars" };
        yield return new object[] { -125.85m, "Negative one hundred twenty-five and 85/100 dollars" };
    }

    [DataTestMethod]
    [DynamicData(nameof(GetRoundingTestCases), DynamicDataSourceType.Method)]
    public void ToString_RoundsAmountToNearestCent(decimal amount, string expected)
    {
        var result = new DollarsAndCents(amount, _converter).ToString();
        Assert.AreEqual(expected, result);
    }
    public static IEnumerable<object[]> GetRoundingTestCases()
    {
        yield return new object[] { 0.004m, "Zero and 00/100 dollars" };               // Rounded down
        yield return new object[] { 0.005m, "Zero and 01/100 dollars" };               // Rounded up
        yield return new object[] { 5.126m, "Five and 13/100 dollars" };               // Rounded up
        yield return new object[] { -9.994m, "Negative nine and 99/100 dollars" };     // Rounded properly across boundary
    }

}
