namespace Boardgames.DataProcessor.ExportDto.Sellers;

using Newtonsoft.Json;

public class ExportBoardgameDto
{
    [JsonProperty(nameof(Name))]
    public string Name { get; set; } = null!;

    [JsonProperty(nameof(Rating))]
    public double Rating { get; set; }

    [JsonProperty(nameof(Mechanics))]
    public string Mechanics { get; set; } = null!;

    [JsonProperty(nameof(Category))]
    public string Category { get; set; } = null!;
}