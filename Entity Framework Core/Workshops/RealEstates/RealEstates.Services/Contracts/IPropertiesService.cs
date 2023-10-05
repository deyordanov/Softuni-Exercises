namespace RealEstates.Services.Contracts;

using Models;

public interface IPropertiesService
{
    void Add(int size, int yardSize, int floor,
        int totalFloors, string district, int year,
        string typeOfProperty, string typeOfBuilding, int price);

    decimal AveragePricePerSquareMeter();
    decimal AveragePricePerSquareMeterForDistrict(int districtId);
    double AverageSizeForDistrict(int districtId);
    IEnumerable<PropertyDataDto> Search(int minPrice, int maxPrice, int minSize, int maxSize);
    IEnumerable<PropertyFullDataDto> ExportPropertyData(int count);
}