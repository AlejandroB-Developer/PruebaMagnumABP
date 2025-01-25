using Microsoft.EntityFrameworkCore;
using PruebaMagnumABP.Domain.Entities;

namespace PruebaMagnumABP.Application.Interfaces.Contexts
{
    public interface IApplicationDbContext
    {
        DbSet<Game> Games { get; set; }
        DbSet<Move> Moves { get; set; }
        DbSet<Player> Players { get; set; }
        DbSet<Round> Rounds { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
