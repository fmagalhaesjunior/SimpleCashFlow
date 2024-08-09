using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Data.DbMapping
{
    public class TransactionDbMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");
            
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Amount).HasColumnName("amount");

            builder.Property(e => e.Type).HasColumnName("type");

            builder.Property(e => e.TransactionDate).HasColumnName("transactiondate");

            builder.Property(e => e.Description).HasColumnName("description");
        }
    }
}
