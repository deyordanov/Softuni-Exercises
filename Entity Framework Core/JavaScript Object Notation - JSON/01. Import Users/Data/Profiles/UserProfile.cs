namespace ProductShop.Data.Profiles;

using AutoMapper;
using DTOs.Import;
using Models;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}