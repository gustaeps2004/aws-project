namespace AwsProject.Infra.Data.Repositories.Collaborator
{
    public interface ICollaboratorRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByCode(Guid code);
        T GetByEmailAndFederalDocument(string email, string federalDocument);
        T GetByEmailAndPassword(string email, string password);
        void Insert(T collaborator);
    }
}