namespace ProductShop.DTOs.Export.UsersAndProducts;

using Newtonsoft.Json;

public class UsersResults
{
    [JsonProperty("usersCount")]
    public int UsersCount { get; set; }
    [JsonProperty("users")] 
    public List<UserDestination> Users { get; set; } = null!;
}