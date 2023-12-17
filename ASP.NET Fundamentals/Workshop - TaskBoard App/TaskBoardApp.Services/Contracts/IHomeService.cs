namespace TaskBoardApp.Services.Contracts;

using Web.ViewModels.Home;

public interface IHomeService
{
    Task<IEnumerable<HomeBoardViewModel>> GetBoardsWithTasksCountAsync();

    Task<int> GetTasksCountForUserAsync(string userId);

    Task<int> GetAllTasksCountAsync();
}