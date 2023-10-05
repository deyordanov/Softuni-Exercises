namespace PetsStore.Services.Data;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetsStore.Data.Models;

public interface IProductsService
{
    IQueryable<Product> GetAllByName(string productName = "");

    IQueryable<Product> GetAllByCategory(string categoryName = "");

    ICollection<string> GetAllProductsCategories();

    Task<Product> GetById(string id);

    Task AddProduct(Product product);
}