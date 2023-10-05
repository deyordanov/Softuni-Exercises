namespace RealEstates.Importer;

public class ImportPropertyDto
{
    public string Url { get; set; } = null!;
    public int Size { get; set; }
    public int YardSize { get; set; }
    public int Floor { get; set; }
    public int TotalFloors { get; set; }
    public string District { get; set; } = null!;
    public int Year { get; set; }
    public string Type { get; set; } = null!;
    public string BuildingType { get; set; } = null!;
    public int Price { get; set; }
}