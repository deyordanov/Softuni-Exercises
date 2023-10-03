namespace PetsStore.Web.ViewModels.Products;

using Data.Models;
using Services.Mapping;

public class ListCategoriesOnProductCreateViewModel : IMapFrom<Category>
{
    public int Id { get; set; }

    public string Name { get; set; }
}