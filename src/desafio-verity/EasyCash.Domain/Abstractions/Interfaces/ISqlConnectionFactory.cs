using System.Data;

namespace EasyCash.Domain.Abstractions.Interfaces;

public interface ISqlConnectionFactory : IDisposable
{
    IDbConnection CreateConnection();
}
