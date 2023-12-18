namespace TaskBoardApp.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Web.ViewModels.Board;

[Authorize]
public class BoardController : Controller
{
    private readonly IBoardService boardService;

    public BoardController(IBoardService boardService)
    {
        this.boardService = boardService;
    }

    public async Task<IActionResult> All()
    {
        IEnumerable<AllBoardsViewModel> boards = await this.boardService.AllAsync();

        return View(boards);
    }
}