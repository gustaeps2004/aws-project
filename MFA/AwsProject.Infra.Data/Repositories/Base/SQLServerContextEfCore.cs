using Microsoft.EntityFrameworkCore;

namespace AwsProject.Infra.Data.Repositories.Base
{
    public class SQLServerContextEfCore(DbContextOptions<SQLServerContextEfCore> options) : DbContext(options)
    { 
        public DbSet<Domain.Models.cad.Collaborator> Collaborators { get; set; }
    }
}