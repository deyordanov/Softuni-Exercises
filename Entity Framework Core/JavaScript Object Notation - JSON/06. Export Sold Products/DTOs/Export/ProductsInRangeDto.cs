namespace ProductShop.DTOs.Export;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public class ProductsInRangeDto
{
    [JsonProperty("name")]
    public string ProductName { get; set; } = null!;
    [JsonProperty("price")]
    public decimal ProductPrice { get; set; }
    [JsonProperty("seller")]
    public string SellerName { get; set; } = null!;
}