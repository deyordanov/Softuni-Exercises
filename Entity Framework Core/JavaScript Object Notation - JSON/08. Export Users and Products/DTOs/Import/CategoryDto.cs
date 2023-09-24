namespace ProductShop.DTOs.Import;

using Newtonsoft.Json;

public class CategoryDto
{
    [JsonProperty("name")] 
    public string? Name { get; set; }
}