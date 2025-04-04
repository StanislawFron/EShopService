using EShop.Application.Services;
using EShop.Domain.Exceptions;
using EShop.Domain.Enums;

namespace EShop.Application.Tests.Services;

public class CreditCardTest
{
    [Fact]
    public void ValidateNumberLength_WhenNumberIncorrectLength_ReturnFalse()
    {
        // Arrange
        var creditCardService = new CreditCardService();
        string number = "1234";

        // Assert
        Assert.Throws<CardNumberTooShortException>(() => creditCardService.ValidateNumberLength(number));
    }

    [Theory]
    [InlineData("1234-5678-9012-3456", "Unknown")]
    [InlineData("3497 7965 8312 797", CreditCardProvider.AmericanExpress)]
    [InlineData("345-470-784-783-010", CreditCardProvider.AmericanExpress)]
    [InlineData("4024-0071-6540-1778", CreditCardProvider.Visa)]
    [InlineData("4532289052809181", CreditCardProvider.Visa)]
    [InlineData("5530016454538418", CreditCardProvider.MasterCard)]
    public void GetCardType_WhenTypeNotFound_ReturnFalse(string number, object expected)
    {
        // Arrange
        var creditCardService = new CreditCardService();

        // Act
        if (expected is CreditCardProvider)
        {
            Assert.Equal(expected, creditCardService.GetCardType(number));
        }
        else
        {
            Assert.Throws<CardTypeInvalidException>(() => creditCardService.GetCardType(number));
        }
    }

    [Theory]
    [InlineData("3497 7965 8312 797", true)]
    [InlineData("345-470-784-783-010", true)]
    [InlineData("378523393817437", true)]
    [InlineData("4024-0071-6540-1778", true)]
    [InlineData("4532 2080 2150 4434", true)]
    [InlineData("4532289052809181", true)]
    [InlineData("5530016454538418", true)]
    [InlineData("5551561443896215", true)]
    [InlineData("5131208517986691", true)]
    [InlineData("123..", false)]
    public void ValidateNumberCharset_WhenBesidesAvailableCharset_ReturnFalse(string number, bool expected)
    {

        // Arrange
        var creditCardService = new CreditCardService();

        if (expected)
        {
            creditCardService.ValidateNumberCharset(number);
        }
        else
        {
            Assert.Throws<CardNumberInvalidException>(() => creditCardService.ValidateNumberCharset(number));
        }
    }

    [Fact]
    public void ValidateNumberByLuhnaAlghoritm_WhenNotPassed_ThrowsCardNumberInvalidException()
    {
        // Arrange
        var creditCardService = new CreditCardService();
        string number = "12345678901234567890";

        // Act & Assert
        Assert.Throws<CardNumberInvalidException>(() => creditCardService.ValidateNumberByLuhnaAlghoritm(number));
    }
}