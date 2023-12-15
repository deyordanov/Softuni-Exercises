namespace ASP.NET_Core_Introduction.Seeding;

using ViewModels;

public static class ProductsData
{
    public static IEnumerable<ProductViewModel> Products =
        new List<ProductViewModel>()
        {
            new ProductViewModel(Guid.NewGuid(), "Bread", 1.20m),
            new ProductViewModel(Guid.NewGuid(), "Milk", 2.5m),
            new ProductViewModel(Guid.NewGuid(), "Bananas", 4.20m),
            new ProductViewModel(Guid.NewGuid(), "Chocolate", 7.00m),
            new ProductViewModel(Guid.NewGuid(), "Oats", 3.20m),
            new ProductViewModel(Guid.NewGuid(), "Peanut Butter", 4.50m),
        };
}