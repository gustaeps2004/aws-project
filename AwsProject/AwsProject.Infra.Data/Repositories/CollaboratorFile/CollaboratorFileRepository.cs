using AwsProject.Domain.Models.cad;
using AwsProject.Infra.Data.Repositories.Base;

namespace AwsProject.Infra.Data.Repositories.CollaboratorFile
{
    public class CollaboratorFileRepository : SQLServerBaseRepository<Domain.Models.cad.CollaboratorFile>, ICollaboratorFileRepository<Domain.Models.cad.CollaboratorFile>
    {
        public CollaboratorFileRepository(SQLServerContextEfCore contextEfCore) : base(contextEfCore)
        {
        }

        public void InsertCollaboratorFile(Domain.Models.cad.CollaboratorFile collaboratorFile)
        {
            Insert(collaboratorFile);
        }
    }
}