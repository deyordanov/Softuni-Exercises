namespace PetsStore.Web.Controllers;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Services.Data;
using Services.Mapping;
using ViewModels.Products;

public class ProductsController : BaseController
{
    private readonly IProductsService productsService;
    private readonly ICategoryService categoryService;

    public ProductsController(IProductsService productsService, ICategoryService categoryService)
    {
        this.productsService = productsService;
        this.categoryService = categoryService;
    }

    [HttpGet]
    public IActionResult Create()
    {
        ICollection<ListCategoriesOnProductCreateViewModel> allCategories = this.categoryService
            .All()
            .To<ListCategoriesOnProductCreateViewModel>()
            .ToArray();

        return this.View(allCategories);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductInputModel inputModel)
    {
        if (!this.ModelState.IsValid)
        {
            return this.RedirectToAction("Create", "Products");
        }

        if (!this.categoryService.ExistsById(inputModel.CategoryId))
        {
            return this.RedirectToAction("Create", "Products");
        }

        Product product = AutoMapperConfig.MapperInstance.Map<Product>(inputModel);
        await this.productsService.AddProduct(product);

        return this.RedirectToAction("All", "Products");
    }

    [HttpGet]
    public async Task<IActionResult> Details(string id)
    {
        Product product = await this.productsService.GetById(id);

        if (product == null)
        {
            return this.RedirectToAction("Error", "Home");
        }

        DetailsProductViewModel viewModel = AutoMapperConfig.MapperInstance.Map<DetailsProductViewModel>(product);

        return this.View(viewModel);
    }

    [HttpGet]
    public IActionResult All(string search)
    {
        AllProductsViewModel viewModel = new AllProductsViewModel()
        {
           AllProducts = this.productsService
               .GetAllByName(search)
               .To<ListAllProductsViewModel>()
               .ToArray(),
           Categories = this.productsService
               .GetAllProductsCategories(),
           SearchQuery = search,
        };

        return this.View(viewModel);
    }
}