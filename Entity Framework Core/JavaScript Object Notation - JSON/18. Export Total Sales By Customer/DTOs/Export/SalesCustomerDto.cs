namespace CarDealer.DTOs.Export;

using Newtonsoft.Json;

public class SalesCustomerDto
{
    [JsonProperty("fullName")]
    public string Name { get; set; } = null!;
    [JsonProperty("boughtCars")]
    public int CarsBought { get; set; }

    [JsonProperty("spentMoney")]
    public decimal MoneySpent
        => this.PartsPrice.Sum();
    [JsonIgnore]
    public List<decimal> PartsPrice { get; set; }
}