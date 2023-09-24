namespace ProductShop.DTOs.Import;

using Newtonsoft.Json;

public class CategoryProductDto
{
    [JsonProperty(nameof(CategoryId))]
    public int CategoryId { get; set; }
    [JsonProperty(nameof(ProductId))]
    public int ProductId { get; set; }
}