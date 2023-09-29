namespace CarDealer.DTOs.Export;

using Newtonsoft.Json;

public class CarDto
{
    [JsonProperty(nameof(Id))]
    public int Id { get; set; }
    [JsonProperty(nameof(Make))]
    public string Make { get; set; } = null!;
    [JsonProperty(nameof(Model))]
    public string Model { get; set; } = null!;
    [JsonProperty(nameof(TraveledDistance))]
    public long TraveledDistance { get; set; }
}