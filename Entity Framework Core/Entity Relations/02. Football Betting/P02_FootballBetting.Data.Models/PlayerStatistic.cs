namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;

public class PlayerStatistic
{
    [ForeignKey(nameof(Game))]
    public int GameId { get; set; }

    public Game Game { get; set; } = null!;

    [ForeignKey(nameof(Player))]
    public int PlayerId { get; set; }

    public Player Player { get; set; } = null!;

    public int ScoredGoals { get; set; }

    public int Assists { get; set; }

    public int MinutesPlayed { get; set; }
}