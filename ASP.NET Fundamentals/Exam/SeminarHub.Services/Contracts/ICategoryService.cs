using SeminarHub.ViewModels.Category;

namespace SeminarHub.Services.Contracts;

public interface ICategoryService
{
    Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();
}