namespace ProductShop.DTOs.Import;

using Newtonsoft.Json;

public class ProductDto
{
    [JsonProperty(nameof(Name))]
    public string Name { get; set; } = null!;
    [JsonProperty(nameof(Price))]
    public decimal Price { get; set; }
    [JsonProperty(nameof(SellerId))]
    public int SellerId { get; set; }
    [JsonProperty(nameof(BuyerId))]
    public int? BuyerId { get; set; }
}