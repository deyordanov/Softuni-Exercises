namespace ProductShop.DTOs.Export.UsersAndProducts;

using Newtonsoft.Json;

public class SoldProductsResult
{
    [JsonProperty("count")]
    public int Count { get; set; }
    [JsonProperty("products")]
    public List<ProductDestination> Products { get; set; } = null!;
}