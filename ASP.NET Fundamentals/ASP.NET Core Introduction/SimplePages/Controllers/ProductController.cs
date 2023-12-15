using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Introduction.Controllers;

using System.Text;
using System.Text.Json;
using Microsoft.Net.Http.Headers;
using ViewModels;
using static Seeding.ProductsData;

public class ProductController : Controller
{
    public IActionResult All()
    {
        return View(Products);
    }

    public IActionResult ById(Guid id)
    {
        ProductViewModel? product 
            = Products.FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            return RedirectToAction("All");
        }

        return View(product);
    }

    public IActionResult AllAsJson()
    {
        return Json(Products, new JsonSerializerOptions()
        {
            WriteIndented = true,
        });
    }

    public IActionResult AllAsText()
    {
        StringBuilder sb = new StringBuilder();

        foreach (ProductViewModel product in Products)
        {
            sb.AppendLine($"{product.Name} - {product.Price}");
        }

        return Content(sb.ToString());
    }

    public IActionResult DownloadProductsData()
    {
        return View();
    }

    public IActionResult AllAsTextFile()
    {
        StringBuilder sb = new StringBuilder();

        foreach (ProductViewModel product in Products)
        {
            sb.AppendLine($"{product.Name} - {product.Price}");
        }

        Response?.Headers?.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");

        byte[] textBytes = Encoding.UTF8.GetBytes(sb.ToString());

        return File(textBytes, "text/plain");
    }

    public IActionResult SearchForProduct()
    {
        return View(Products);
    }

    [HttpPost]
    public IActionResult SearchForProduct(string keyword)
    {
        if (string.IsNullOrEmpty(keyword))
        {
            return RedirectToAction("SearchForProduct");
        }

        List<ProductViewModel> products = Products
            .Where(p => p.Name.ToLower().Contains(keyword.ToLower()))
            .ToList();

        return View(products);
    }
}