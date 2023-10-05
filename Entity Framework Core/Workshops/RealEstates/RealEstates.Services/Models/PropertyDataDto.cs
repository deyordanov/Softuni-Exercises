namespace RealEstates.Services.Models;

public class PropertyDataDto
{
    public string DistrictName { get; set; } = null!;
    public int Size { get; set; }
    public int Price { get; set; }
    public string BuildingType { get; set; } = null!;
    public string PropertyType { get; set; } = null!; 
}