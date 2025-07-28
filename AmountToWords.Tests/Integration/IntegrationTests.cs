
using AmountToWords.Lib.Mapping;
using AmountToWords.Lib.Models;
using AmountToWords.Lib.Services;
using System;
using System.Runtime.CompilerServices;
using System.Threading;

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


}
