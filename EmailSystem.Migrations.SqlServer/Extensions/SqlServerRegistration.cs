using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SqlServerMigrations.Extensions;

public static class SqlServerRegistration
{
    public static void RegisterSqlServerDbContexts<TDbContext>(this IServiceCollection services, string connectionString)
        where TDbContext : DbContext
    {
        var migrationsAssembly = typeof(SqlServerRegistration).GetTypeInfo().Assembly.GetName().Name;

        services.AddDbContextPool<TDbContext>(options =>
            options.UseSqlServer(
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
