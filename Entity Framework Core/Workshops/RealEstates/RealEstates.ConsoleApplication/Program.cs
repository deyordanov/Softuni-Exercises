using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RealEstates.Data;
using RealEstates.Services;
using RealEstates.Services.Contracts;
using RealEstates.Services.Models;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

ApplicationDbContext context = new ApplicationDbContext();

while (true)
{
    Console.Clear();
    Console.WriteLine("Choose an option:");
    Console.WriteLine("0. Exit");
    Console.WriteLine("1. Property Search");
    Console.WriteLine("2. Most Expensive Properties");
    Console.WriteLine("3. Average Price Per Square Meter");
    Console.WriteLine("4. Add Tag");
    Console.WriteLine("5. Insert Properties Tags");
    Console.WriteLine("6. Export Property Data In XML Format");
    bool isParsed = int.TryParse(Console.ReadLine(), out int option);
    if (isParsed && option == 0)
    {
        break;
    }
    if (isParsed &&
        option is >= 1 && option <= 6)
    {
        switch (option)
        {
            case 1:
                PropertySearch(context);
                break;
            case 2:
                GetMostExpensiveDistricts(context);
                break;
            case 3:
                GetAveragePricePerSquareMeter(context);
                break;
            case 4:
                AddTag(context);
                break;
            case 5:
                InsertPropertiesTags(context);
                break;
            case 6:
                ExportPropertyDataXML(context);
                break;
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}

static void PropertySearch(ApplicationDbContext context)
{
    Console.WriteLine("Min Price:");
    int minPrice = int.Parse(Console.ReadLine());
    Console.WriteLine("Max Price:");
    int maxPrice = int.Parse(Console.ReadLine());
    Console.WriteLine("Min Size:");
    int minSize = int.Parse(Console.ReadLine());
    Console.WriteLine("Max Size:");
    int maxSize = int.Parse(Console.ReadLine());

    IPropertiesService service = new PropertiesService(context);
    IEnumerable<PropertyDataDto> properties = service.Search(minPrice, maxPrice, minSize, maxSize);
    
    foreach (PropertyDataDto property in properties)
    {
        Console.WriteLine($"{property.DistrictName} -> {property.PropertyType}, {property.BuildingType} => {property.Size}m², {property.Price}€");
    }
}

static void ExportPropertyDataXML(ApplicationDbContext context)
{
    Console.WriteLine("Count:");
    int count = int.Parse(Console.ReadLine());

    IPropertiesService service = new PropertiesService(context);
    PropertyFullDataDto[] dataToExport = service.ExportPropertyData(count).ToArray();

    StringBuilder sb = new StringBuilder();

    XmlRootAttribute root = new XmlRootAttribute("Properties");

    XmlSerializer serializer = new XmlSerializer(typeof(PropertyFullDataDto[]), root);

    XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
    namespaces.Add(string.Empty, string.Empty);

    using StringWriter writer = new StringWriter(sb);

    serializer.Serialize(writer, dataToExport, namespaces);

    Console.WriteLine(sb.ToString().TrimEnd());
}

static void GetMostExpensiveDistricts(ApplicationDbContext context)
{
    Console.WriteLine("Count:");
    int count = int.Parse(Console.ReadLine());

    IDistrictsService service = new DistrictsService(context);
    IEnumerable<DistrictDataDto> districts = service.GetMostExpensiveDistricts(count);
    foreach (DistrictDataDto district in districts)
    {
        Console.WriteLine($"{district.Name} => {district.PropertiesCount}, {district.AveragePricePerSquareMeter:F2}€/m²");
    }
}

static void GetAveragePricePerSquareMeter(ApplicationDbContext context)
{
    IPropertiesService service = new PropertiesService(context);
    Console.WriteLine($"Average price per square meter: {service.AveragePricePerSquareMeter():F2}€/m²");
}

static void AddTag(ApplicationDbContext context)
{
    Console.WriteLine("Tag Name:");
    string tagName = Console.ReadLine();
    Console.WriteLine("Tag Importance:");
    bool isParsed = int.TryParse(Console.ReadLine(), out int tagImportance);

    IPropertiesService propertiesService = new PropertiesService(context);
    ITagsService service = new TagsService(context, propertiesService);

    if (isParsed)
    {
        service.Add(tagName!, tagImportance);
    }
    else
    {
        service.Add(tagName!);
    }
}

static void InsertPropertiesTags(ApplicationDbContext context)
{
    Console.WriteLine("Insertion has begun!");

    IPropertiesService propertiesService = new PropertiesService(context);
    ITagsService service = new TagsService(context, propertiesService);

    service.InsertPropertiesTags();

    Console.WriteLine("Insertion has finished!");
}