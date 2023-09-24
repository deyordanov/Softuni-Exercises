namespace ProductShop.DTOs.Export.UsersAndProducts;

using Newtonsoft.Json;

public class UserDestination
{
    [JsonProperty("firstName")]
    public string? FirstName { get; set; }
    [JsonProperty("lastName")]
    public string LastName { get; set; } = null!;
    [JsonProperty("age")]
    public int? Age { get; set; }
    [JsonProperty("soldProducts")]
    public SoldProductsResult SoldProducts { get; set; } = null!;
}