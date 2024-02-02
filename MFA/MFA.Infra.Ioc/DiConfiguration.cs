using MFA.Infra.Data.Repositories.Base;
using Microsoft.Extensions.DependencyInjection;

namespace MFA.Infra.Ioc
{
    public static class DiConfiguration
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<SQLServerBaseRepository>();

            return services;
        }
    }
}