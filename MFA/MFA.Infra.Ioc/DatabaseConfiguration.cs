using MFA.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MFA.Infra.Ioc
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services)
        {
            services.AddDbContext<SQLServerContextEfCore>(options => 
            options.UseSqlServer(Environment.GetEnvironmentVariable("SQL_SERVER_CONNECTION_STRING")));

            return services;
        }
    }
}
