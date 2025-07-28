using AmountToWords.Lib.Services;
using AmountToWords.Web.Controllers;
using AmountToWords.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AmountToWords.Tests;

[TestClass]
public class AmountControllerTests
{
    private Mock<IAmountToWordsConverter>? _mockConverter;

    [TestInitialize]
    public void Setup()
    {
        _mockConverter = new Mock<IAmountToWordsConverter>();
    }

    [TestMethod]
    public void Convert_ValidModel_SetsAmountWords_ReturnsIndexView()
    {
        // Arrange
        decimal input = 2523.04m;
        var expectedWords = "Two thousand five hundred twenty-three and 04/100 dollars";

        var mockConverter = new Mock<IAmountToWordsConverter>();

        // Simulate the conversion steps
        mockConverter
            .Setup(c => c.GetThreeDigitGroups(2523))
            .Returns(new List<int> { 523, 2 });

        mockConverter
            .Setup(c => c.GetMagnitudeWords(It.IsAny<List<int>>()))
            .Returns("two thousand five hundred twenty-three");

        var controller = new AmountController(mockConverter.Object);
        var model = new AmountViewModel { Amount = input };

        controller.ModelState.Clear(); // Valid model state

        // Act
        var result = controller.Convert(model) as ViewResult;
        var returnedModel = result?.Model as AmountViewModel;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Index", result.ViewName);
        Assert.IsNotNull(returnedModel);
        Assert.AreEqual(input, returnedModel.Amount);
        Assert.AreEqual(expectedWords, returnedModel.AmountWords);
    }
}
