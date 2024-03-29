﻿namespace Forum.Data;

using Configuration;
using Microsoft.EntityFrameworkCore;
using Models;

public class ForumDbContext : DbContext
{
    public ForumDbContext(DbContextOptions<ForumDbContext> options)
        : base(options) { }

    public DbSet<Post> Posts { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PostEntityConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}