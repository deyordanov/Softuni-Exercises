namespace TaskBoardApp.Data.Configurations;

using System.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using Seeders;

public class BoardEntityConfiguration : IEntityTypeConfiguration<Board>
{
    private readonly BoardSeeder seeder;

    public BoardEntityConfiguration()
    {
        this.seeder = new BoardSeeder();
    }

    public void Configure(EntityTypeBuilder<Board> builder)
    {
        builder
            .HasData(seeder.GenerateBoards());
    }
}