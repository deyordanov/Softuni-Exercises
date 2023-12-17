namespace TaskBoardApp.Services.Board;

using Contracts;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels.Board;
using Web.ViewModels.Task;

public class BoardService : IBoardService
{
    private readonly ApplicationDbContext dbContext;

    public BoardService(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<AllBoardsViewModel>> AllAsync()
    {
        IEnumerable<AllBoardsViewModel> allBoards = await this
            .dbContext
            .Boards
            .Select(b => new AllBoardsViewModel()
            {
                Id = b.Id,
                Name = b.Name,
                Tasks = b
                    .Tasks
                    .Select(t => new AllTasksViewModel()
                    {
                        Id = t.Id,
                        Description = t.Description,
                        Owner = t.User.UserName!,
                        Title = t.Title
                    })
            }).ToListAsync();

        return allBoards;
    }

    public async Task<IEnumerable<DropdownBoardViewModel>> AllForDropdownAsync()
    {
        IEnumerable<DropdownBoardViewModel> boards = await this
            .dbContext 
            .Boards
            .Select(b => new DropdownBoardViewModel()
            {
                Id = b.Id,
                Name = b.Name,
            }).ToListAsync();

        return boards;
    }

    public async Task<bool> ExistsByIdAsync(int id)
    {
        bool result = await this
            .dbContext
            .Boards
            .AnyAsync(b => b.Id == id);

        return result;
    }
}