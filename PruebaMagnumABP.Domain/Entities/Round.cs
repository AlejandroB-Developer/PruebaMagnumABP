namespace PruebaMagnumABP.Domain.Entities;

public partial class Round
{
    public int Id { get; set; }
    public int GameId { get; set; }
    public int Player1MoveId { get; set; }
    public int Player2MoveId { get; set; }
    public string? Result { get; set; }
    public DateTime? Date { get; set; }
    public virtual Game Game { get; set; } = null!;
    public virtual Move Player1Move { get; set; } = null!;
    public virtual Move Player2Move { get; set; } = null!;
}
