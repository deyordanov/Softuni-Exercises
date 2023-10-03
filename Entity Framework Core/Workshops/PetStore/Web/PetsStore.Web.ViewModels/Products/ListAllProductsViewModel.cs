namespace PetsStore.Web.ViewModels.Products;

using Data.Models;
using Services.Mapping;

public class ListAllProductsViewModel : IMapFrom<Product>
{
    public string Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public string CategoryName { get; set; }
}