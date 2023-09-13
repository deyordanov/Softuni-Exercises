namespace ProductShop.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasMany(u => u.ProductsBought)
            .WithOne(p => p.Buyer)
            .HasForeignKey(p => p.BuyerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(u => u.ProductsSold)
            .WithOne(p => p.Seller)
            .HasForeignKey(p => p.SellerId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}