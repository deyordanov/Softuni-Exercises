namespace CarDealer.DTOs.Import;

using Newtonsoft.Json;

public class CarDto
{
    public CarDto()
    {
        this.PartsId = new List<int>();
    }
    [JsonProperty("make")]
    public string Make { get; set; } = null!;
    [JsonProperty("model")]
    public string Model { get; set; } = null!;
    [JsonProperty("traveledDistance")]
    public long TravelledDistance { get; set; }
    [JsonProperty("partsId")]
    public ICollection<int> PartsId { get; set; }
}