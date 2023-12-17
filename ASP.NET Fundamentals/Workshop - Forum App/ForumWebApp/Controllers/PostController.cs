namespace Forum.App.Controllers;

using Common.Exceptions.Post;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Contracts;
using ViewModels.Post;
using static Forum.Common.ExceptionMessages.Post;

public class PostController : Controller
{
    private readonly IProductService productService;

    public PostController(IProductService productService)
    {
        this.productService = productService;
    }

    public async Task<IActionResult> All()
    {
        IEnumerable<PostListViewModel> allPosts = await productService.ListAllAsync();

        return View(allPosts);
    }

    public async Task<IActionResult> Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(PostFormModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            await this.productService.AddPostAsync(model);
        }
        catch (Exception)
        {
            ModelState.AddModelError(string.Empty, UnexpectedErrorWhenAddingPostMessage);

            return View(model);
        }

        return RedirectToAction("All", "Post");
    }

    public async Task<IActionResult> Edit(string id)
    {
        try
        {
            PostFormModel post = await this.productService.GetPostById(id);

            return View(post);
        }
        catch (Exception)
        {
            return RedirectToAction("All", "Post");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(string id, PostFormModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            await this.productService.EditPostByIdAsync(id, model);

            return RedirectToAction("All", "Post");

        }
        catch (Exception)
        {
            ModelState.AddModelError(string.Empty, UnexpectedErrorWhenEditingPostMessage);

            return View(model);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            await this.productService.DeletePostByIdAsync(id);
        }
        catch (Exception)
        {

        }

        return RedirectToAction("All", "Post");
    }
}