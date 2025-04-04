namespace EShop.Domain.Exceptions;

public class CardNumberTooShortException : Exception
{
    public CardNumberTooShortException() : base("Card number is too short") {}
    public CardNumberTooShortException(Exception innerException) : base("Card number is too short", innerException) {}
}