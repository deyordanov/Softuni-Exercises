namespace PetsStore.Services.Data;

using System.Collections.Generic;
using System.Linq;
using PetsStore.Data.Models;

public interface ICategoryService
{
    IQueryable<Category> All();

    bool ExistsById(int id);
}