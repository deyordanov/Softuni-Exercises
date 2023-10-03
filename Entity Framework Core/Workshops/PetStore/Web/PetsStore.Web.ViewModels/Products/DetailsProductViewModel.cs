﻿namespace PetsStore.Web.ViewModels.Products;

using AutoMapper;
using Data.Models;
using Services.Mapping;

public class DetailsProductViewModel : IMapFrom<Product>, IHaveCustomMappings
{
    public string Name { get; set; }

    public decimal Price { get; set; }

    public string ImageURL { get; set; }

    public string CategoryName { get; set; }
    public void CreateMappings(IProfileExpression configuration)
    {
        configuration.CreateMap<Product, DetailsProductViewModel>()
            .ForMember(d => d.CategoryName,
                o => o.MapFrom(s => s.Category.Name));
    }
}