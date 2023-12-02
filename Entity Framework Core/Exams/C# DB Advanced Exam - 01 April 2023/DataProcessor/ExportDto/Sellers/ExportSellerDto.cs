namespace Boardgames.DataProcessor.ExportDto.Sellers;

using Newtonsoft.Json;

public class ExportSellerDto
{
    [JsonProperty(nameof(Name))]
    public string Name { get; set; } = null!;

    [JsonProperty(nameof(Website))]
    public string Website { get; set; } = null!;

    [JsonProperty(nameof(Boardgames))]
    public ExportBoardgameDto[] Boardgames { get; set; } = null!;
}