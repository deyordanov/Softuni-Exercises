namespace PetsStore.Services.Data;

using System.Collections.Generic;
using System.Linq;
using PetsStore.Data.Common.Repositories;
using PetsStore.Data.Models;

public class CategoryService : ICategoryService
{
    private readonly IDeletableEntityRepository<Category> categoryRepository;

    public CategoryService(IDeletableEntityRepository<Category> categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    public IQueryable<Category> All()
        => this.categoryRepository.All();

    public bool ExistsById(int id)
        => this.categoryRepository.AllAsNoTracking().FirstOrDefault(p => p.Id == id) == null;
}