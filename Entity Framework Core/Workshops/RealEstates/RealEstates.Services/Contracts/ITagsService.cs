namespace RealEstates.Services.Contracts;

public interface ITagsService
{
    void Add(string name, int? importance = null);
    void InsertPropertiesTags();
}