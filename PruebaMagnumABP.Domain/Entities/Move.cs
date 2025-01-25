namespace PruebaMagnumABP.Domain.Entities;

public partial class Move
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public virtual ICollection<Round> RoundPlayer1Moves { get; set; } = new List<Round>();
    public virtual ICollection<Round> RoundPlayer2Moves { get; set; } = new List<Round>();
}
