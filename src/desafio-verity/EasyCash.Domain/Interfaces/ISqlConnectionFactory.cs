using System.Data;

namespace EasyCash.Domain.Interfaces;

public interface ISqlConnectionFactory : IDisposable
{
    IDbConnection CreateConnection();
}
