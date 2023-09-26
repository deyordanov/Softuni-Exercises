namespace CarDealer.DTOs.Import;

using Newtonsoft.Json;

public class SupplierDto
{
    [JsonProperty("name")]
    public string Name { get; set; } = null!;
    [JsonProperty("isImporter")]
    public bool IsImporter { get; set; }
}