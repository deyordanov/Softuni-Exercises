namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common;

public class Game
{
    public Game()
    {
        this.PlayersStatistics = new HashSet<PlayerStatistic>();
        this.Bets = new HashSet<Bet>();
    }
    [Key]
    public int GameId { get; set; }

    [ForeignKey(nameof(HomeTeam))]
    public int HomeTeamId { get; set; }

    public Team HomeTeam { get; set; } = null!;

    [ForeignKey(nameof(AwayTeam))]
    public int AwayTeamId { get; set; }

    public Team AwayTeam { get; set; } = null!;

    public int HomeTeamGoals { get; set; }

    public int AwayTeamGoals { get; set; }

    public DateTime DateTime { get; set; }

    public double HomeTeamBetRate { get; set; }

    public double AwayTeamBetRate { get; set; }

    public double DrawBetRate { get; set; }

    [MaxLength(ValidationConstants.GameResultMaxLength)]
    public string? Result { get; set; }

    public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; }

    public virtual ICollection<Bet> Bets { get; set; }
}