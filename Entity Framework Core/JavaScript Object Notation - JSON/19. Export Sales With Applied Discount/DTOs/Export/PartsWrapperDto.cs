namespace CarDealer.DTOs.Export;

using Newtonsoft.Json;

public class PartsWrapperDto
{
    public PartsWrapperDto()
    {
        this.Parts = new List<PartsPartDto>();
    }
    [JsonProperty("car")]
    public PartsCarDto Car { get; set; }
    [JsonProperty("parts")]
    public ICollection<PartsPartDto> Parts { get; set; }
}