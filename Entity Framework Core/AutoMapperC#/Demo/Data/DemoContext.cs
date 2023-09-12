namespace Demo.Data;

using Common;
using Microsoft.EntityFrameworkCore;
using Models;

public class DemoContext : DbContext
{
    public DemoContext() { }

    public DemoContext(DbContextOptions options)
        : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Address> Addresses { get; set; }

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

    }
}