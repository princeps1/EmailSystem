using MySqlMigrations.Extensions;
using SqlServerMigrations.Extensions;
using PostgreMigrations.Extensions;

namespace PrincepsLibrary.Extensions;

public static class DatabaseExtensions
{
    public static void ConfigureDatabase<TDbContext>(this WebApplicationBuilder builder)
        where TDbContext : DbContext
    {
        string? databaseProviderConfig = builder.Configuration["DatabaseProviderConfiguration:DatabaseProvider"];
        if (string.IsNullOrWhiteSpace(databaseProviderConfig))
        {
            throw new Exception("Konfiguracija za DatabaseProvider je null ili prazna.");
        }

        Enum.TryParse<DatabaseProvider>(databaseProviderConfig.Trim(), out DatabaseProvider databaseProviderEnum);
        
        var connectionString = builder.Configuration["ConnectionStrings:MailSystemCS"];
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new Exception("Connection string je null ili prazan.");
        }

        switch (databaseProviderEnum)
        {
            case DatabaseProvider.SqlServer:
                builder.Services.RegisterSqlServerDbContexts<TDbContext>(connectionString);
                break;
            case DatabaseProvider.PostgreSQL:
                builder.Services.RegisterPostgreDbContexts<TDbContext>(connectionString);
                break;
            case DatabaseProvider.MySQL:
                builder.Services.RegisterMySqlDbContexts<TDbContext>(connectionString);
                break;
            default:
                throw new Exception("Nepodrzan tip baze.");
        }
    }
}
