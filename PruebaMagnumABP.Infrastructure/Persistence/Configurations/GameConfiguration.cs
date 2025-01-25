using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaMagnumABP.Domain.Entities;

namespace PruebaMagnumABP.Infrastructure.Persistence.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Games__3214EC075A3C407F");

            builder.Property(e => e.EndDate).HasColumnType("datetime");
            builder.Property(e => e.StartDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            builder.HasOne(d => d.Player1).WithMany(p => p.GamePlayer1s)
                .HasForeignKey(d => d.Player1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Games__Player1Id__3B75D760");

            builder.HasOne(d => d.Player2).WithMany(p => p.GamePlayer2s)
                .HasForeignKey(d => d.Player2Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Games__Player2Id__3C69FB99");

            builder.HasOne(d => d.Winner).WithMany(p => p.GameWinners)
                .HasForeignKey(d => d.WinnerId)
                .HasConstraintName("FK__Games__WinnerId__3D5E1FD2");
        }
    }
}
