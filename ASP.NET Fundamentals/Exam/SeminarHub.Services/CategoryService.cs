namespace SeminarHub.Services;

using Contracts;
using Data;
using Microsoft.EntityFrameworkCore;
using ViewModels.Category;

public class CategoryService : ICategoryService
{
    private readonly SeminarHubDbContext _dbContext;

    public CategoryService(SeminarHubDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
    {
        return await this
            ._dbContext
            .Categories
            .AsNoTracking()
            .Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name,
            })
            .ToListAsync();
    }
}