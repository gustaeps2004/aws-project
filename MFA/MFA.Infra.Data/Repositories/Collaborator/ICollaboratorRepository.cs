namespace MFA.Infra.Data.Repositories.Collaborator
{
    public interface ICollaboratorRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByCode(Guid code);
        void Insert(T collaborator);
    }
}