﻿// <auto-generated />
using System;
using Forum.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Forum.Data.Migrations
{
    [DbContext(typeof(ForumDbContext))]
    [Migration("20231228074505_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Forum.Data.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9b7a178b-3e08-4264-aa4d-c0f83d21dd71"),
                            Content = "A brief look into aeronautical advancements.",
                            Title = "Exploring the Sky"
                        },
                        new
                        {
                            Id = new Guid("5a5c9def-916e-43ae-aa89-a11b426b7c7c"),
                            Content = "Predicting the next big trends in technology.",
                            Title = "The Future of Software"
                        },
                        new
                        {
                            Id = new Guid("4d0ce161-1f1a-490f-a91c-524c9afbcbd5"),
                            Content = "Balancing workout routines with a busy schedule.",
                            Title = "Fitness and You"
                        },
                        new
                        {
                            Id = new Guid("839aa81e-78d0-4df1-9481-dff5be26b04c"),
                            Content = "The journey of becoming a leading aeronautical engineer.",
                            Title = "Engineering Dreams"
                        },
                        new
                        {
                            Id = new Guid("91307edc-06ec-48fe-8836-78e4eb484558"),
                            Content = "Solving complex problems in .Net and React.",
                            Title = "Coding Challenges"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
