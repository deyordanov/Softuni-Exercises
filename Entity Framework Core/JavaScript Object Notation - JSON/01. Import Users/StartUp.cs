using ProductShop.Data;

namespace ProductShop
{
    using AutoMapper;
    using Data.Profiles;
    using DTOs.Import;
    using Models;
    using Newtonsoft.Json;

    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            string json = File.ReadAllText("../../../Datasets/users.json");
            
            Console.WriteLine(ImportUsers(context, json));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new UserProfile()));

            IMapper mapper = new Mapper(config);

            UserDto[]? userDtos = 
                JsonConvert.DeserializeObject<UserDto[]>(inputJson);

            User[]? users =
                mapper.Map<User[]>(userDtos);

            context.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }


    }
}