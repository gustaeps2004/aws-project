using MFA.Infra.Data.Repositories.Base.SQLServer;
using Microsoft.Extensions.DependencyInjection;

namespace MFA.Infra.Ioc
{
    public static class DiConfiguration
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<ISQLServerBaseRepository, SQLServerBaseRepository>();

            return services;
        }
    }
}