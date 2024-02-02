using MFA.Infra.Data.Repositories.Base;

namespace MFA.Infra.Data.Repositories.Collaborator
{
    public class CollaboratorRepository : SQLServerBaseRepository, ICollaboratorRepository<Domain.Models.cad.Collaborator>
    {
        public IEnumerable<Domain.Models.cad.Collaborator> GetAll()
        {
            const string sql = @"SELECT * FROM cad.Collaborator WITH (NOLOCK)";
            return RawQueryResult<Domain.Models.cad.Collaborator>(sql);
        }

        public Domain.Models.cad.Collaborator GetByCode(Guid code)
        {
            const string sql = @"DECLARE @code UNIQUEIDENTIFIER = @Code

                                SELECT * 
                                FROM 
	                                cad.Collaborator WITH (NOLOCK)
                                WHERE 
	                                Code = @code";

            return RawQueryResult<Domain.Models.cad.Collaborator>(sql).FirstOrDefault();
        }
    }
}