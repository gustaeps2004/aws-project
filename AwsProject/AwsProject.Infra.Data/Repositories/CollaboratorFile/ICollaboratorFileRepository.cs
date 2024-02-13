namespace AwsProject.Infra.Data.Repositories.CollaboratorFile
{
    public interface ICollaboratorFileRepository<T> where T : class
    {
        void InsertCollaboratorFile(T collaboratorFile);
    }
}