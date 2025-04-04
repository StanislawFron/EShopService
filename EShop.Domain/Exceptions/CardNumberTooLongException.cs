namespace EShop.Domain.Exceptions;

public class CardNumberTooLongException : Exception
{
    public CardNumberTooLongException() : base("Card number is too long") {}
    public CardNumberTooLongException(Exception innerException) : base("Card number is too long", innerException) {}
}