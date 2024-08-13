using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class SummaryContext : DbContext
    {
        public SummaryContext(DbContextOptions<SummaryContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<DailySummary> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SummaryContext).Assembly);
            modelBuilder.HasPostgresExtension("uuid-ossp");
            modelBuilder.Entity<DailySummary>(entity =>
            {
                entity.ToTable("dailysummary");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.TotalDebit).HasColumnName("totaldebit");
                entity.Property(e => e.TotalCredit).HasColumnName("totalcredit");
                entity.Property(e => e.Balance).HasColumnName("balance");
            });
        }
    }
}
