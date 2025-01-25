namespace PruebaMagnumABP.Domain.Entities;

public partial class Game
{
    public int Id { get; set; }
    public int Player1Id { get; set; }
    public int Player2Id { get; set; }
    public int? WinnerId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public virtual Player Player1 { get; set; } = null!;
    public virtual Player Player2 { get; set; } = null!;
    public virtual ICollection<Round> RoundGames { get; set; } = new List<Round>();
    public virtual ICollection<Round> RoundPlayer1Moves { get; set; } = new List<Round>();
    public virtual ICollection<Round> RoundPlayer2Moves { get; set; } = new List<Round>();
    public virtual Player? Winner { get; set; }
}
