using MFA.Domain.Models.cad;
using MFA.Infra.Data.Repositories.Base;
using MFA.Infra.Data.Repositories.Collaborator;
using Microsoft.Extensions.DependencyInjection;

namespace MFA.Infra.Ioc
{
    public static class DiConfiguration
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            #region SINGLETON

            services.AddSingleton<SQLServerBaseRepository>();

            #endregion

            #region TRANSIENT

            services.AddTransient<ICollaboratorRepository<Collaborator>, CollaboratorRepository>();

            #endregion

            return services;
        }
    }
}