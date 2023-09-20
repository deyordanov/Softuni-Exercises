namespace ProductShop.DTOs.Import;

public class UserDto
{
    public string? FirstName { get; set; }
    public string LastName { get; set; } = null!;
    public int? Age { get; set; }
}