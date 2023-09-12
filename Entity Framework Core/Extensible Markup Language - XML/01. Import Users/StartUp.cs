using ProductShop.Data;

namespace ProductShop
{
    using System.Xml.Serialization;
    using AutoMapper;
    using DTOs.Import;
    using Models;

    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            string xml = File.ReadAllText("../../../Datasets/users.xml");

            Console.WriteLine(ImportUsers(context, xml));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new ProductShopProfile()));

            IMapper mapper = new Mapper(config);

            XmlRootAttribute root = new XmlRootAttribute("Users");

            XmlSerializer serializer = new XmlSerializer(typeof(ImportUserDto[]), root);

            using StringReader reader = new StringReader(inputXml);

            ImportUserDto[]? importedDtos 
                = (ImportUserDto[]?)serializer.Deserialize(reader);

            User[] users =
                mapper.Map<User[]>(importedDtos);

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }
    }
}