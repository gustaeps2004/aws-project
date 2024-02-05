using MFA.Application.Mapper;
using MFA.Application.Services.Authentication;
using MFA.Application.Services.Collaborator;
using MFA.Domain.Models.cad;
using MFA.Infra.Data.Repositories.Collaborator;
using Microsoft.Extensions.DependencyInjection;

namespace MFA.Infra.Ioc
{
    public static class DiConfiguration
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {

            #region TRANSIENT

            services.AddTransient<ICollaboratorRepository<Collaborator>, CollaboratorRepository>();
            services.AddTransient<ICollaboratorApplicationService, CollaboratorApplicationService>();
            services.AddTransient<IAuthenticationApplicationServices, AuthenticationApplicationServices>();

            #endregion

            services.AddAutoMapper(typeof(DtoToDomainProfile));

            return services;
        }
    }
}