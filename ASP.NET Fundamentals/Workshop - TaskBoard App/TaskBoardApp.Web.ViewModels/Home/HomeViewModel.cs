namespace TaskBoardApp.Web.ViewModels.Home;

public class HomeViewModel
{
    public HomeViewModel()
    {
        this.BoardsWithTasksCount = new HashSet<HomeBoardViewModel>();
    }

    public int AllTasksCount { get; set; }

    public IEnumerable<HomeBoardViewModel> BoardsWithTasksCount { get; set; }

    public int UserTasksCount { get; set; }
}