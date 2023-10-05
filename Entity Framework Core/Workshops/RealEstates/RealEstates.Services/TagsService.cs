namespace RealEstates.Services;

using Contracts;
using Data;
using RealEstates.Models;

public class TagsService : BaseService, ITagsService
{
    private readonly ApplicationDbContext context;
    private readonly IPropertiesService service;
    private readonly ICollection<Tag> tags;
    public TagsService(ApplicationDbContext context, IPropertiesService service)
    {
        this.context = context;
        this.service = service;
        this.tags = this.context.Tags.ToHashSet();
    }
    public void Add(string name, int? importance = null)
    {
        Tag? dbTag = this.context.Tags
            .FirstOrDefault(t => t.Name == name);
        if (dbTag == null)
        {
            dbTag = new Tag()
            {
                Name = name,
                Importance = importance
            };

            this.context.Tags.Add(dbTag);
            context.SaveChanges();
        }
    }

    public void InsertPropertiesTags()
    {
        Property[] properties = this.context.Properties.ToArray();

        foreach (Property property in properties)
        {
            decimal averageDistrictPrice = service
                .AveragePricePerSquareMeterForDistrict(property.DistrictId);
            if (property.Price.HasValue && property.Price >= averageDistrictPrice)
            {
                property.Tags.Add(GetTag("скъп-имот"));
            }
            else if (property.Price.HasValue)
            {
                property.Tags.Add(GetTag("евтин-имот"));
            }

            DateTime currentDate = DateTime.Now.AddYears(-10);
            if (property.Year.HasValue && property.Year >= currentDate.Year)
            {
                property.Tags.Add(GetTag("ново-строителство"));
            }
            else if (property.Year.HasValue)
            {
                property.Tags.Add(GetTag("старо-строителство"));
            }

            double averageDistrictSize = service
                .AverageSizeForDistrict(property.DistrictId);
            if (property.Size >= averageDistrictSize)
            {
                property.Tags.Add(GetTag("голям-имот"));
            }
            else
            {
                property.Tags.Add(GetTag("малък-имот"));
            }

            if (property.Floor.HasValue && property.Floor == 1)
            {
                property.Tags.Add(GetTag("първи-етаж"));
            }

            if (property.Floor.HasValue && property.TotalFloors.HasValue &&
                property.Floor == property.TotalFloors)
            {
                property.Tags.Add(GetTag("последен-етаж"));
            }
        }

        context.SaveChanges();
    }

    private Tag GetTag(string tagName)
        => this.tags.First(t => t.Name == tagName);
}