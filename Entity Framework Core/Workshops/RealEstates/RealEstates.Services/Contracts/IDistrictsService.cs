namespace RealEstates.Services.Contracts;

using Models;

public interface IDistrictsService
{
    IEnumerable<DistrictDataDto> GetMostExpensiveDistricts(int count);
}