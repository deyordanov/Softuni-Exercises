namespace CarDealer.DTOs.Export;

using Newtonsoft.Json;

public class CustomerDto
{
    [JsonProperty(nameof(Name))] 
    public string Name { get; set; } = null!;
    [JsonProperty(nameof(BirthDate))] 
    public string BirthDate { get; set; } = null!;
    [JsonProperty(nameof(IsYoungDriver))]
    public bool IsYoungDriver { get; set; }
}