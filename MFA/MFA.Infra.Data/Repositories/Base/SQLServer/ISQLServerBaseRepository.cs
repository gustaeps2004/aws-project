namespace MFA.Infra.Data.Repositories.Base.SQLServer
{
    public interface ISQLServerBaseRepository
    {
        IQueryable<T> RawQueryResult<T>(string query, object? parameters) where T : class;
        int Execute(string query, object? parameters);
    }
}