namespace PruebaMagnumABP.Domain.Entities;

public partial class Player
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? AvatarUrl { get; set; }
    public DateTime? StartDate { get; set; }
    public virtual ICollection<Game> GamePlayer1s { get; set; } = new List<Game>();
    public virtual ICollection<Game> GamePlayer2s { get; set; } = new List<Game>();
    public virtual ICollection<Game> GameWinners { get; set; } = new List<Game>();
}
