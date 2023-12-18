namespace TaskBoardApp.Services.Contracts;

using TaskBoardApp.Web.ViewModels.Board;

public interface IBoardService
{
    Task<IEnumerable<AllBoardsViewModel>> AllAsync();

    Task<IEnumerable<DropdownBoardViewModel>> AllForDropdownAsync();

    Task<bool> ExistsByIdAsync(int id);
}