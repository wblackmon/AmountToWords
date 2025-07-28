using AmountToWords.Lib.Mapping;
using AmountToWords.Lib.Services;
using System.Diagnostics;

namespace AmountToWords.Tests;

[TestClass]
public class AmountToWordsConverterTests
{
    private AmountToWordsConverter _converter;
    [TestInitialize]
    public void Setup()
    {
        var maps = new NumberMaps();
        _converter = new AmountToWordsConverter(maps);
    }

    [TestMethod]
    public void GetThreeDigitGroups_ReturnsThreeDigitList()
    {
        // Arrange
        long input = 987654321;

        // Act
        var result = _converter.GetThreeDigitGroups(input);

        // Assert
        CollectionAssert.AreEqual(new List<int> { 321, 654, 987 }, result);
    }

    [TestMethod]
    public void GetMagnitudeWords_handlesFullMagnitudeString()
    {
        // Arrange
        var groups = new List<int> { 321, 654, 987 }; // 987 million, 456 thousand, 789

        // Act
        var result = _converter.GetMagnitudeWords(groups);

        // Assert
        Assert.AreEqual("nine hundred eighty-seven million six hundred fifty-four thousand three hundred twenty-one", result);
    }


    [TestMethod]
    public void ConvertThreeDigitGroupToWords_HandlesFullThreeDigits()
    {
        // Arrange
        int input = 987;

        // Act
        var result = _converter.ConvertThreeDigitGroupToWords(input);

        // Assert
        Assert.AreEqual("nine hundred eighty-seven", result);
    }

    [TestMethod]
    public void ConvertThreeDigitGroupToWords_HandlesUnderTwenty()
    {
        // Arrange
        int input = 18;

        // Act
        var result = _converter.ConvertThreeDigitGroupToWords(input);

        // Assert
        Assert.AreEqual("eighteen", result);
    }

    [TestMethod]
    public void ConvertThreeDigitGroupToWords_ZeroReturnsEmptyString()
    {
        // Arrange
        int input = 0;

        // Act
        var result = _converter.ConvertThreeDigitGroupToWords(input);

        // Assert
        Assert.AreEqual(string.Empty, result);
    }

    [TestMethod]
    public void GetMagnitudeWords_NoZeroGroups_HandlesSingleDigits()
    {
        // Arrange
        var groups = new List<int> { 7, 6, 0 }; // => "seven"

        // Act
        var result = _converter.GetMagnitudeWords(groups);

        // Assert
        Assert.AreEqual("six thousand seven", result);
    }


}
