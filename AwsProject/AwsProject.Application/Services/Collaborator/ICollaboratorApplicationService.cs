using AwsProject.Application.DTOs.cad;
using Microsoft.AspNetCore.Http;

namespace AwsProject.Application.Services.Collaborator
{
    public interface ICollaboratorApplicationService
    {
        IEnumerable<Domain.Models.cad.Collaborator> GetAll();
        Domain.Models.cad.Collaborator GetByCode(Guid code);
        Domain.Models.cad.Collaborator Insert(CollaboratorDto collaboratorDto);
        void FormFileToMemoryStream(IFormFile file);
    }
}