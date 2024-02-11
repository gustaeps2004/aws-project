using AwsProject.Application.Mapper;
using AwsProject.Application.Services.Authentication;
using AwsProject.Application.Services.Collaborator;
using AwsProject.Domain.Models.cad;
using AwsProject.Infra.Data.Repositories.Collaborator;
using Microsoft.Extensions.DependencyInjection;

namespace AwsProject.Infra.Ioc
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