namespace ProductShop.DTOs.Export.UsersAndProducts;

using Newtonsoft.Json;

public class ProductDestination
{
    [JsonProperty("name")]
    public string Name { get; set; } = null!;
    [JsonProperty("price")]
    public decimal Price { get; set; }
}