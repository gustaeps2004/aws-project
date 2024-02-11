using AwsProject.Infra.Data.Repositories.Base;

namespace AwsProject.Infra.Data.Repositories.Collaborator
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
            const string sql = @"DECLARE @collaboratorCode UNIQUEIDENTIFIER = @Code

                                SELECT * 
                                FROM 
	                                cad.Collaborator WITH (NOLOCK)
                                WHERE 
	                                Code = @collaboratorCode";

            return RawQueryResult<Domain.Models.cad.Collaborator>(sql, new { Code = code }).FirstOrDefault();
        }

        public Domain.Models.cad.Collaborator GetByEmailAndFederalDocument(string email, string federalDocument)
        {
            const string sql = @"DECLARE
	                                @collabEmail VARCHAR(150) = @Email,
	                                @collabFD VARCHAR(14) = @FederalDocument

                                SELECT *
                                FROM
	                                cad.Collaborator WITH (NOLOCK)
                                WHERE
	                                Email = @collabEmail
                                OR
	                                FederalDocument = @collabFD";

            return RawQueryResult<Domain.Models.cad.Collaborator>(sql, new { Email = email, FederalDocument = federalDocument }).FirstOrDefault();
        }

        public Domain.Models.cad.Collaborator GetByEmailAndPassword(string email, string password)
        {
            return SingleOrDefault(collab => collab.Email.Equals(email) && collab.Password.Equals(password));
        }

        public void InsertCollaborator(Domain.Models.cad.Collaborator collaborator)
        {
            Insert(collaborator);
        }
    }
}