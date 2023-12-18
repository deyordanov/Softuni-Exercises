namespace TaskBoardApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Extensions;
using Services.Contracts;
using Services.Home;
using TaskBoardApp.Web.ViewModels;
using Web.ViewModels.Home;

public class HomeController : Controller
{
    private readonly IHomeService homeService;

    public HomeController(IHomeService homeService)
    {
        this.homeService = homeService;
    }

    public async Task<IActionResult> Index()
    {
        IEnumerable<HomeBoardViewModel> boards = await this.homeService.GetBoardsWithTasksCountAsync();

        int userTasksCount = -1;
        if (User?.Identity?.IsAuthenticated ?? false)
        {
            string userId = User.GetId();
            userTasksCount = await this.homeService.GetTasksCountForUserAsync(userId);
        }

        HomeViewModel homeModel = new HomeViewModel()
        {
            AllTasksCount = await this.homeService.GetAllTasksCountAsync(),
            BoardsWithTasksCount = boards,
            UserTasksCount = userTasksCount,
        };

        return View(homeModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}