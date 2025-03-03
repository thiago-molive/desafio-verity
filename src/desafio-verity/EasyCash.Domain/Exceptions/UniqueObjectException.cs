namespace EasyCash.Domain.Exceptions;

public sealed class UniqueObjectException : Exception
{
    public UniqueObjectException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}