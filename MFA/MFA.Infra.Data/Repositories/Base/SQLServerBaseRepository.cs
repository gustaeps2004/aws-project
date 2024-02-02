using Dapper;
using MFA.Domain.Validation;
using System.Data.SqlClient;

namespace MFA.Infra.Data.Repositories.Base
{
    public class SQLServerBaseRepository
    {
        private readonly string _connectionString;

        public SQLServerBaseRepository()
        {
            _connectionString = Environment.GetEnvironmentVariable("SQL_SERVER_CONNECTION_STRING")!;
        }

        public IQueryable<T> RawQueryResult<T>(string query, object? parameters = null) where T : class
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                var result = connection.Query<T>(query, parameters);
                connection.Close();

                return result.AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception("Internal error: " + ex);
            }
        }

        public int Execute(string query, object? parameters = null)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                var result = connection.Execute(query, parameters);
                connection.Close();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Internal error: " + ex);
            }
        }
    }
}