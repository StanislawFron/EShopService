using System.Text.RegularExpressions;
using EShop.Domain.Exceptions;
using EShop.Domain.Enums;

namespace EShop.Application.Services;

public class CreditCardService
{
    public bool ValidateNumberLength(string number)
    {
        if (number.Length < 13)
        {
            throw new CardNumberTooShortException();
        }
        if (number.Length > 19)
        {
            throw new CardNumberTooLongException();
        }

        return true;
    }

    public CreditCardProvider GetCardType(string number)
    {
        number = number.Replace(" ", "").Replace("-", "");

        if (Regex.IsMatch(number, @"^4(\d{12}|\d{15}|\d{18})$"))
            return CreditCardProvider.Visa;
        else if (Regex.IsMatch(number, @"^(5[1-5]\d{14}|2(2[2-9][1-9]|2[3-9]\d{2}|[3-6]\d{3}|7([01]\d{2}|20\d))\d{10})$"))
            return CreditCardProvider.MasterCard;

        if (Regex.IsMatch(number, @"^3[47]\d{13}$"))
            return CreditCardProvider.AmericanExpress;

        throw new CardTypeInvalidException();
    }
    public void ValidateNumberCharset(string input)
    {
        if (!input.All(c => char.IsDigit(c) || c == ' ' || c == '-'))
        {
            throw new CardNumberInvalidException("Card number contains invalid characters.");
        }
    }

    public void ValidateNumberByLuhnaAlghoritm(string cardNumber)
    {
        cardNumber = cardNumber.Replace(" ", "");
        
        if (!cardNumber.All(char.IsDigit))
        {
            throw new CardNumberInvalidException("Card number contains invalid characters.");
        }

        int sum = 0;
        bool alternate = false;

        for (int i = cardNumber.Length - 1; i >= 0; i--)
        {
            int digit = cardNumber[i] - '0';

            if (alternate)
            {
                digit *= 2;
                if (digit > 9)
                    digit -= 9;
            }

            sum += digit;
            alternate = !alternate;
        }

        if (sum % 10 != 0)
        {
            throw new CardNumberInvalidException("Invalid card number checksum.");
        }
    }
}
