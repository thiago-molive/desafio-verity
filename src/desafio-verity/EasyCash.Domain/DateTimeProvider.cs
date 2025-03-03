using EasyCash.Domain.Interfaces;

namespace EasyCash.Domain;

public sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
