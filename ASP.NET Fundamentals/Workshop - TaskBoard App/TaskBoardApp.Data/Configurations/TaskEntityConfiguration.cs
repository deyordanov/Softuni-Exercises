namespace TaskBoardApp.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using Seeders;

public class TaskEntityConfiguration : IEntityTypeConfiguration<Task>
{
    private readonly TaskSeeder seeder;

    public TaskEntityConfiguration()
    {
        this.seeder = new TaskSeeder();
    }

    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder
            .HasOne(t => t.Board)
            .WithMany(b => b.Tasks)
            .HasForeignKey(t => t.BoardId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasData(seeder.GenerateTasks());
    }
}