using MFA.Infra.Data.Repositories.Base;

namespace MFA.Infra.Data.Repositories.Collaborator
{
    public class CollaboratorRepository : SQLServerBaseRepository<Domain.Models.cad.Collaborator>, ICollaboratorRepository<Domain.Models.cad.Collaborator>
    {
        public CollaboratorRepository(SQLServerContextEfCore contextEfCore) : base(contextEfCore)
        {
        }

        public IEnumerable<Domain.Models.cad.Collaborator> GetAll()
        {
            const string sql = @"SELECT * FROM cad.Collaborator WITH (NOLOCK) ORDER BY Name";
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