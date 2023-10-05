using Newtonsoft.Json;
using RealEstates.Data;
using RealEstates.Importer;
using RealEstates.Services;
using RealEstates.Services.Contracts;

ApplicationDbContext context = new ApplicationDbContext();
IPropertiesService service = new PropertiesService(context);

string json = File.ReadAllText("../../../Properties1.json.txt");

ImportJson(json);

void ImportJson(string jsonFile)
{
    ImportPropertyDto[]? importedDtos = JsonConvert.DeserializeObject<ImportPropertyDto[]>(jsonFile);

    foreach (ImportPropertyDto dto in importedDtos)
    {
        service.Add(dto.Size, dto.YardSize, dto.Floor, dto.TotalFloors,
            dto.District, dto.Year, dto.Type,
            dto.BuildingType, dto.Price);
    }
}