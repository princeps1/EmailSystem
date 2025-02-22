using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PostgreMigrations.Extensions;

public static class PostgreRegistration
{
    public static void RegisterPostgreDbContexts<TDbContext>(this IServiceCollection services, string connectionString)
        where TDbContext : DbContext
    {
        var migrationsAssembly = typeof(PostgreRegistration).GetTypeInfo().Assembly.GetName().Name;

        services.AddDbContextPool<TDbContext>(options =>
            options.UseNpgsql(
                connectionString,
                sql =>
                {
                    sql.MigrationsAssembly(migrationsAssembly)
                       .EnableRetryOnFailure()
                       .CommandTimeout(120);
                    sql.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                })
            .EnableSensitiveDataLogging()
        );
    }
}
