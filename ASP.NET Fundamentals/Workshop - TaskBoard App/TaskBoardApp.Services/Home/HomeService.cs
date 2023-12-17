namespace TaskBoardApp.Services.Home;

using Contracts;
using Data;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels.Home;

public class HomeService : IHomeService
{
    private readonly ApplicationDbContext dbContext;

    public HomeService(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<IEnumerable<HomeBoardViewModel>> GetBoardsWithTasksCountAsync()
    {
        List<string> boardNames = await this
            .dbContext
            .Boards
            .Select(b => b.Name)
            .Distinct()
            .ToListAsync();

        List<HomeBoardViewModel> boardsWithTasksCount = new List<HomeBoardViewModel>();
        foreach (string boardName in boardNames)
        {
            boardsWithTasksCount.Add(new HomeBoardViewModel()
            {
                BoardName = boardName,
                TasksCount = await this
                    .dbContext
                    .Tasks
                    .Where(t => t.Board.Name == boardName)
                    .CountAsync(),
            });
        }

        return boardsWithTasksCount;
    }

    public Task<int> GetTasksCountForUserAsync(string userId)
    {
        return this
            .dbContext
            .Tasks
            .Where(t => t.OwnerId == userId)
            .CountAsync();
    }

    public Task<int> GetAllTasksCountAsync()
    {
        return this
            .dbContext
            .Tasks
            .CountAsync();
    }
}