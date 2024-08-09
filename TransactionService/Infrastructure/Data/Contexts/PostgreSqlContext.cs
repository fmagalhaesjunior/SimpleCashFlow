using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Contexts
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) 
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgreSqlContext).Assembly);
            modelBuilder.HasPostgresExtension("uuid-ossp");
        }
    }
}
