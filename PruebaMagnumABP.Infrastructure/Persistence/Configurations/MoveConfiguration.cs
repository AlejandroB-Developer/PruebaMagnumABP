using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaMagnumABP.Domain.Entities;

namespace PruebaMagnumABP.Infrastructure.Persistence.Configurations
{
    public class MoveConfiguration : IEntityTypeConfiguration<Move>
    {
        public void Configure(EntityTypeBuilder<Move> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Moves__3214EC072F829FAF");

            builder.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false);
        }
    }
}
