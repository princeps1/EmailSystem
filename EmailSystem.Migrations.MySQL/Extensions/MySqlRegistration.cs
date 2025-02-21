using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MySqlMigrations.Extensions;

public static class MySqlRegistration
{
    public static void RegisterMySqlDbContexts<TDbContext>(this IServiceCollection services, string connectionString)
        where TDbContext : DbContext
    {
        var migrationsAssembly = typeof(MySqlRegistration).GetTypeInfo().Assembly.GetName().Name;

        services.AddDbContextPool<TDbContext>(options =>
            options.UseMySql(
                connectionString,
                new MySqlServerVersion(new Version(8, 0, 33)), 
                mysql =>
                {
                    mysql.MigrationsAssembly(migrationsAssembly)
                         .EnableRetryOnFailure()
                         .CommandTimeout(120);
                    mysql.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                })
            .EnableSensitiveDataLogging()
        );
    }
}
