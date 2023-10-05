namespace RealEstates.Services;

using AutoMapper.QueryableExtensions;
using Contracts;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using RealEstates.Models;

public class PropertiesService : BaseService, IPropertiesService
{
    private readonly ApplicationDbContext context;
    public PropertiesService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public void Add(int size, int yardSize, int floor, 
        int totalFloors, string district, int year, 
        string typeOfProperty, string typeOfBuilding, int price)
    {
        Property property = new Property()
        {
            Size = size,
            YardSize = yardSize <= 0 ? null : yardSize,
            Floor = floor <= 0 || floor > 255 ? null : (byte)floor,
            TotalFloors = totalFloors <= 0 || totalFloors > 255 ? null : (byte)totalFloors,
            Year = year <= 0 ? null : year,
            Price = price <= 0 ? null : price
        };

        District? dbDistrict = context.Districts
            .FirstOrDefault(d => d.Name == district);
        if (dbDistrict == null)
        {
            dbDistrict = new District() { Name = district };
        }
        property.District = dbDistrict;

        PropertyType? dbPropertyType = context.PropertyTypes
            .FirstOrDefault(pt => pt.Name == typeOfProperty);
        if (dbPropertyType == null)
        {
            dbPropertyType = new PropertyType() { Name = typeOfProperty };
        }
        property.PropertyType = dbPropertyType;

        BuildingType? dbBuildingType = context.BuildingTypes
            .FirstOrDefault(bt => bt.Name == typeOfBuilding);
        if (dbBuildingType == null)
        {
            dbBuildingType = new BuildingType() { Name = typeOfBuilding };
        }
        property.BuildingType = dbBuildingType;

        context.Properties.Add(property);
        context.SaveChanges();
    }

    public IEnumerable<PropertyFullDataDto> ExportPropertyData(int count)
        => this.context.Properties
            .ProjectTo<PropertyFullDataDto>(this.Mapper.ConfigurationProvider)
            .Take(count);

    public decimal AveragePricePerSquareMeter()
        => this.context.Properties
            .Where(p => p.Price.HasValue)
            .Average(p => p.Price.Value / (decimal)p.Size);

    public decimal AveragePricePerSquareMeterForDistrict(int districtId)
        => this.context.Properties
            .Where(p => p.Price.HasValue && p.District.Id == districtId)
            .Average(p => p.Price.Value / (decimal)p.Size);

    public double AverageSizeForDistrict(int districtId)
        => this.context.Properties
            .Average(p => p.Size);

    public IEnumerable<PropertyDataDto> Search(int minPrice, int maxPrice, int minSize, int maxSize)
        => this.context.Properties
            .AsNoTracking()
            .Where(p => p.Price >= minPrice && 
                        p.Price <= maxPrice &&
                        p.Size >= minSize && 
                        p.Size <= maxSize)
            .ProjectTo<PropertyDataDto>(this.Mapper.ConfigurationProvider)
            .OrderByDescending(p => p.Price)
            .ToArray();
}