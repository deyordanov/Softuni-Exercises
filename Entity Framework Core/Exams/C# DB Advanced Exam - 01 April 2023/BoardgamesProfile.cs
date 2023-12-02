namespace Boardgames
{
    using AutoMapper;
    using Data.Models;
    using DataProcessor.ImportDto.Creators;
    using DataProcessor.ImportDto.Sellers;

    public class BoardgamesProfile : Profile
    {
        public BoardgamesProfile()
        {
            CreateMap<ImportCreatorDto, Creator>()
                .ForMember(dest => dest.Boardgames, opt => opt.Ignore());

            CreateMap<ImportBoardgameDto, Boardgame>();

            CreateMap<ImportSellerDto, Seller>()
                .ForMember(dest => dest.BoardgamesSellers, opt => opt.Ignore());
        }
    }
}