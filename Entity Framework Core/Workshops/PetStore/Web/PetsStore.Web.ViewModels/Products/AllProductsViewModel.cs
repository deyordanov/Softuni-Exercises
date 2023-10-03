namespace PetsStore.Web.ViewModels.Products;

using System.Collections;
using System.Collections.Generic;

public class AllProductsViewModel
{
    public ICollection<ListAllProductsViewModel> AllProducts { get; set; }

    public ICollection<string> Categories { get; set; }

    public string SearchQuery { get; set; }
}