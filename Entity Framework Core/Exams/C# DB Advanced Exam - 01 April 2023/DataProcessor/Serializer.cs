namespace Boardgames.DataProcessor
{
    using System.Text;
    using System.Xml.Serialization;
    using Boardgames.Data;
    using ExportDto.Creators;
    using ExportDto.Sellers;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using ExportBoardgameDto = ExportDto.Creators.ExportBoardgameDto;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCreatorDto[]), new XmlRootAttribute("Creators"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            StringWriter writer = new StringWriter(sb);

            var creators = context
                .Creators
                .Where(c => c.Boardgames.Count >= 1)
                .Select(c => new ExportCreatorDto()
                {
                    Name = c.FirstName + " " + c.LastName,
                    Boardgames = c
                        .Boardgames
                        .Select(b => new ExportBoardgameDto()
                        {
                            Name = b.Name,
                            YearPublished = b.YearPublished,
                        })
                        .OrderBy(b => b.Name)
                        .ToArray(),
                    BoardgamesCount = c.Boardgames.Count
                })
                .OrderByDescending(c => c.BoardgamesCount)
                .ThenBy(c => c.Name)
                .ToArray();

            serializer.Serialize (writer, creators, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context
                .Sellers
                .AsNoTracking()
                .Where(s => s.BoardgamesSellers.Count >= 1 && s.BoardgamesSellers.Any(bs =>
                    bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating))
                .Select(s => new ExportSellerDto()
                {
                    Name = s.Name,
                    Website = s.Website,
                    Boardgames = s
                        .BoardgamesSellers
                        .Where(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating)
                        .Select(bs => new ExportDto.Sellers.ExportBoardgameDto()
                        {
                            Name = bs.Boardgame.Name,
                            Rating = bs.Boardgame.Rating,
                            Category = bs.Boardgame.CategoryType.ToString(),
                            Mechanics = bs.Boardgame.Mechanics
                        })
                        .OrderByDescending(b => b.Rating)
                        .ThenBy(b => b.Name)
                        .ToArray()
                })
                .OrderByDescending(b => b.Boardgames.Length)
                .ThenBy(b => b.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(sellers, Formatting.Indented);
        }
    }
}