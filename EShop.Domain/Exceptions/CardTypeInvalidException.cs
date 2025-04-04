namespace EShop.Domain.Exceptions;

public class CardTypeInvalidException : Exception
{
    public CardTypeInvalidException() : base("Card type is invalid") {}
    public CardTypeInvalidException(Exception innerException) : base("Card type is invalid", innerException) {}
}