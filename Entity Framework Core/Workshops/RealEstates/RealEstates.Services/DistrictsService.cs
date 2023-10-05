namespace RealEstates.Services;

using AutoMapper.QueryableExtensions;
using Contracts;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;

public class DistrictsService : BaseService, IDistrictsService
{
    private readonly ApplicationDbContext context;
    public DistrictsService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public IEnumerable<DistrictDataDto> GetMostExpensiveDistricts(int count)
        => this.context.Districts
            .AsNoTracking()
            .ProjectTo<DistrictDataDto>(this.Mapper.ConfigurationProvider)
            .OrderByDescending(d => d.AveragePricePerSquareMeter)
            .Take(count)
            .ToArray();
}