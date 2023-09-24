namespace ProductShop.DTOs.Export.SoldProducts;

using Newtonsoft.Json;

public class SoldProductsUserDto
{
    [JsonProperty("firstName")]
    public string? FirstName { get; set; }
    [JsonProperty("lastName")]
    public string LastName { get; set; } = null!;
    [JsonProperty("soldProducts")]
    public List<SoldProductsProductDto> ProductsSold { get; set; }
}