using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaMagnumABP.Domain.Entities;

namespace PruebaMagnumABP.Infrastructure.Persistence.Configurations
{
    public class RoundConfiguration : IEntityTypeConfiguration<Round>
    {
        public void Configure(EntityTypeBuilder<Round> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Rounds__3214EC0707505F30");

            builder.Property(e => e.Id);
            builder.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.Player1MoveId);
            builder.Property(e => e.Player2MoveId);
            builder.Property(e => e.GameId);
            builder.Property(e => e.Result)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.HasOne(d => d.Player1Move).WithMany(p => p.RoundPlayer1Moves)
                .HasForeignKey(d => d.Player1MoveId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rounds__Player1M__440B1D61");

            builder.HasOne(d => d.Player2Move).WithMany(p => p.RoundPlayer2Moves)
                .HasForeignKey(d => d.Player2MoveId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rounds__Player2M__44FF419A");

            builder.HasOne(d => d.Game).WithMany(p => p.RoundGames)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rounds__GameId__4316F928");
        }
    }
}
