namespace RealEstates.Services;

using AutoMapper;
using Profiles;

public abstract class BaseService
{
    public BaseService()
    {
        InitializeAutoMapper();
    }

    protected IMapper Mapper { get; set; }

    private void InitializeAutoMapper()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<RealEstatesProfile>());

        this.Mapper = config.CreateMapper();
    }
}