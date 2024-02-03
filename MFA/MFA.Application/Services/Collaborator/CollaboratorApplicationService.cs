using MFA.Application.DTOs.cad;
using MFA.Domain.Validation;
using MFA.Infra.Data.Repositories.Collaborator;

namespace MFA.Application.Services.Collaborator
{
    public class CollaboratorApplicationService(
        ICollaboratorRepository<Domain.Models.cad.Collaborator> _collaboratorRepository) : ICollaboratorApplicationService
    {
        public IEnumerable<Domain.Models.cad.Collaborator> GetAll()
        {
            // apply filter here, when front is done
            return _collaboratorRepository.GetAll();
        }

        public Domain.Models.cad.Collaborator GetByCode(Guid code)
        {
            var collaborator = _collaboratorRepository.GetByCode(code) ?? throw new MFAException("Collaborator not located.");
            return collaborator;
        }

        public void Insert(CollaboratorDto collaboratorDto)
        {
            var errorList = collaboratorDto.Validate();

            if (errorList.Any())
                throw new MFAException(string.Join(";", errorList));
        }
    }
}