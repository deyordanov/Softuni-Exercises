namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Boardgames.Data;
    using Data.Models;
    using ImportDto.Creators;
    using ImportDto.Sellers;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile(typeof(BoardgamesProfile)); });

            IMapper mapper = new Mapper(config);

            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(ImportCreatorDto[]), new XmlRootAttribute("Creators"));

            using StringReader reader = new StringReader(xmlString);

            ImportCreatorDto[] importedDtos = (ImportCreatorDto[])serializer.Deserialize(reader)!;

            ICollection<Creator> validCreators = new HashSet<Creator>();

            foreach (ImportCreatorDto creatorDto in importedDtos)
            {
                if (!IsValid(creatorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Creator creator = mapper.Map<Creator>(creatorDto);

                foreach (ImportBoardgameDto boardgameDto in creatorDto.Boardgames)
                {
                    if (!IsValid(boardgameDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Boardgame boardgame = mapper.Map<Boardgame>(boardgameDto);

                    creator.Boardgames.Add(boardgame);
                }

                sb.AppendLine(string.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName,
                    creator.Boardgames.Count));

                validCreators.Add(creator);
            }

            context.Creators.AddRange(validCreators);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BoardgamesProfile>();
            });

            IMapper mapper = new Mapper(config);

            StringBuilder sb = new StringBuilder();

            ImportSellerDto[] importedDtos = JsonConvert.DeserializeObject<ImportSellerDto[]>(jsonString)!;

            ICollection<Seller> validSellers = new HashSet<Seller>();

            ICollection<int> boardgameIds = context.Boardgames.Select(b => b.Id).ToArray();

            foreach (ImportSellerDto sellerDto in importedDtos)
            {
                if (!IsValid(sellerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Seller seller = mapper.Map<Seller>(sellerDto);

                foreach (int boardgameId in sellerDto.Boardgames.Distinct())
                {
                    if (!boardgameIds.Contains(boardgameId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Boardgame boardgame = context.Boardgames.Find(boardgameId)!;

                    seller.BoardgamesSellers.Add(new BoardgameSeller()
                    {
                        BoardgameId = boardgameId,
                        Boardgame = boardgame
                    });
                }

                sb.AppendLine(string.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count));

                validSellers.Add(seller);
            }

            context.Sellers.AddRange(validSellers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}