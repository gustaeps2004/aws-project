using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Linq.Expressions;
using static Dapper.SqlMapper;

namespace AwsProject.Infra.Data.Repositories.Base
{
    public class SQLServerBaseRepository<T> where T : class
    {
        private readonly string _connectionString;
        private readonly SQLServerContextEfCore _contextEfCore;

        public SQLServerBaseRepository(SQLServerContextEfCore contextEfCore)
        {
            _connectionString = Environment.GetEnvironmentVariable("SQL_SERVER_CONNECTION_STRING_DAPPER")!;
            _contextEfCore = contextEfCore;
        }

        public IQueryable<TEntity> RawQueryResult<TEntity>(string query, object? parameters = null) where TEntity : class
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                var result = connection.Query<TEntity>(query, parameters);
                connection.Close();

                return result.AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception("Internal error: " + ex);
            }
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _contextEfCore.Set<T>().AsNoTracking().SingleOrDefault(predicate);
        }

        public void Insert(T entity)
        {
            try
            {
                _contextEfCore.Add(entity);
                _contextEfCore.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Internal error: " + ex);
            }
        }

        public void Update(T entity)
        {
            try
            {
                _contextEfCore.Update(entity);
                _contextEfCore.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Internal error: " + ex);
            }
        }
    }
}