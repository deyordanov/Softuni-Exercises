namespace P02_FootballBetting.Data;

using Common;
using Microsoft.EntityFrameworkCore;
using Models;

public class FootballBettingContext : DbContext
{
    public FootballBettingContext() { }

    public FootballBettingContext(DbContextOptions options) 
        :base(options) { }

    public DbSet<Team> Teams { get; set; } = null!;

    public DbSet<Color> Colors { get; set; } = null!;

    public DbSet<Town> Towns { get; set; } = null!;

    public DbSet<Country> Countries { get; set; } = null!;

    public DbSet<Player> Players { get; set; } = null!;

    public DbSet<Position> Positions { get; set; } = null!;

    public DbSet<PlayerStatistic> PlayersStatistics { get; set; } = null!;

    public DbSet<Game> Games { get; set; } = null!;

    public DbSet<Bet> Bets { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(Config.ConnectionString);
        }
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlayerStatistic>(x =>
        {
            x.HasKey(k => new { k.GameId, k.PlayerId });
        });

        base.OnModelCreating(modelBuilder);
    }
}