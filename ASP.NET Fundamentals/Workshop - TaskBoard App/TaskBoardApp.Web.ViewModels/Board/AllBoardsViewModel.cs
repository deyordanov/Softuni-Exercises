namespace TaskBoardApp.Web.ViewModels.Board;

using Data.Models;
using Task;

public class AllBoardsViewModel
{
    public AllBoardsViewModel()
    {
        this.Tasks = new HashSet<AllTasksViewModel>();
    }
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public IEnumerable<AllTasksViewModel> Tasks { get; set; }
}