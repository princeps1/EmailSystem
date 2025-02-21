using MySqlMigrations.Extensions;
using PostGreMigrations.Extensions;

namespace EmailSystem.Services.Implementations;
public static class RegisterDbContexts
{
    public static void Register<TDbContext>(this IServiceCollection services, string connectionString, string provider)
        where TDbContext : DbContext
    {
        switch (provider.Trim())
        {
            case "SqlServer":
                SqlServerMigrations.Extensions.SqlServerRegistration.RegisterSqlServerDbContexts<TDbContext>(services, connectionString);
                break;
            case "PostgreSQL":
                PostgreRegistration.RegisterPostgreDbContexts<TDbContext>(services, connectionString);
                break;
            case "MySQL":
                MySqlRegistration.RegisterMySqlDbContexts<TDbContext>(services, connectionString);
                break;
            default:
                throw new Exception("Nepodrzan tip baze");
        }
    }
}
