// ReSharper disable UnusedMember.Local
// ReSharper disable InconsistentNaming
namespace PetsStore.Services.Data;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetsStore.Data.Common.Repositories;
using PetsStore.Data.Models;

public class ProductsService : IProductsService
{
    private readonly IDeletableEntityRepository<Product> productRepository;

    public ProductsService(IDeletableEntityRepository<Product> repo)
    {
        this.productRepository = repo;
    }

    public IQueryable<Product> GetAllByName(string productName = null)
    {
        if (productName != null)
        {
            return this.productRepository
                .All()
                .Where(p => p.Name.ToLower() == productName.ToLower());
        }

        return this.productRepository.All();
    }

    public IQueryable<Product> GetAllByCategory(string categoryName = null)
    {
        if (categoryName != null)
        {
            return this.productRepository
                .All()
                .Where(p => p.Category.Name.ToLower() == categoryName.ToLower());
        }

        return this.productRepository.All();
    }

    public ICollection<string> GetAllProductsCategories()
        => this.productRepository
            .AllAsNoTracking()
            .Select(p => p.Category.Name)
            .Distinct()
            .ToArray();

    public async Task<Product> GetById(string id)
        => await this.productRepository.All().FirstOrDefaultAsync(p => p.Id == id);

    public async Task AddProduct(Product product)
    {
        await this.productRepository.AddAsync(product);
        await this.productRepository.SaveChangesAsync();
    }
}
