﻿namespace EasyCash.Domain.Interfaces;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
