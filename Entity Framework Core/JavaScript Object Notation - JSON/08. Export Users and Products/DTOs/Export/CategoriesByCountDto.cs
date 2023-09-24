namespace ProductShop.DTOs.Export;

using Newtonsoft.Json;

public class CategoriesByCountDto
{
    [JsonProperty("category")]
    public string Name { get; set; } = null!;
    [JsonProperty("productsCount")]
    public int ProductsCount { get; set; }
    [JsonProperty("averagePrice")]
    public string AverageProductPrice { get; set; } = null!;
    [JsonProperty("totalRevenue")]
    public string TotalRevenue { get; set; } = null!;
}