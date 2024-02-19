namespace SeminarHub.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(GenerateCategories());
    }

    private static ICollection<Category> GenerateCategories()
    {
        return new HashSet<Category>()
        {
            new Category()
            {
                Id = 1,
                Name = "Technology & Innovation"
            },
            new Category()
            {
                Id = 2,
                Name = "Business & Entrepreneurship"
            },
            new Category()
            {
                Id = 3,
                Name = "Science & Research"
            },
            new Category()
            {
                Id = 4,
                Name = "Arts & Culture"
            }
        };
    }
}