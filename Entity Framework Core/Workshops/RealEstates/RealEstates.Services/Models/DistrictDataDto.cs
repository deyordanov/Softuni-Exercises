namespace RealEstates.Services.Models;

public class DistrictDataDto
{
    public string Name { get; set; } = null!;
    public decimal AveragePricePerSquareMeter { get; set; }
    public int PropertiesCount { get; set; }
}