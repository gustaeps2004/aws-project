namespace MFA.Application.Services.Collaborator
{
    public interface ICollaboratorApplicationService
    {
        IEnumerable<Domain.Models.cad.Collaborator> GetAll();
        Domain.Models.cad.Collaborator GetByCode(Guid code);
    }
}
